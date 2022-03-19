using NServiceBus;
using NServiceBus.ProtoBuf;

static class ScheduledTaskHelper
{
#pragma warning disable CS0618
    static Type scheduledTaskType = typeof(ScheduledTask);
    public static Type WrapperType = typeof(ScheduledTaskWrapper);

    public static bool IsScheduleTask(this Type messageType) =>
        messageType == scheduledTaskType;

    public static ScheduledTaskWrapper ToWrapper(ScheduledTask target) =>
        new()
        {
            TaskId = target.TaskId,
            Name = target.Name,
            Every = target.Every,
        };

    public static object FromWrapper(ScheduledTaskWrapper target) =>
        new ScheduledTask
        {
            TaskId = target.TaskId,
            Name = target.Name,
            Every = target.Every
        };
}