namespace FRMJX.Infrastructure.Infrastructure.Logging.Infrastructure;

using Microsoft.Extensions.Logging;

public class LogEvent
{
	public static EventId ExceptionMiddlewareEvent { get; } = new EventId((int)LogEventEnum.ExceptionMiddleware, nameof(ExceptionMiddlewareEvent));
}
