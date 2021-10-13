using NServiceBus;
using NServiceBus.ProtoBuf;

static class ScheduledTaskHelper
{
    static Type scheduledTaskType = typeof(ScheduledTask);
    public static Type WrapperType = typeof(ScheduledTaskWrapper);

    public static bool IsScheduleTask(this Type messageType)
    {
        return messageType == scheduledTaskType;
    }

    public static ScheduledTaskWrapper ToWrapper(ScheduledTask target)
    {
        return new()
        {
            TaskId = target.TaskId,
            Name = target.Name,
            Every = target.Every,
        };
    }

    public static object FromWrapper(ScheduledTaskWrapper target)
    {
        return new ScheduledTask
        {
            TaskId = target.TaskId,
            Name = target.Name,
            Every = target.Every
        };
    }
}