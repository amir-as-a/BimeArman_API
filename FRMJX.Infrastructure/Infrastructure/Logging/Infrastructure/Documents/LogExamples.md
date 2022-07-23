# Log examples

``` C#
var innerException = new System.Exception("Inner Exception");

var secondIinnerException = new System.Exception("Second Inner Exception", innerException);

var exception = new System.Exception("Main exception", secondIinnerException);


logger.LogTrace(LogEvent.ActionEvent, "Trace Log Sample");

logger.LogDebug(LogEvent.ActionEvent, "Debug Log Sample");

logger.LogInformation(LogEvent.ActionEvent, "Information Log Sample");

logger.LogWarning(LogEvent.ActionEvent, "Warning Log Sample");

logger.LogError(LogEvent.ActionEvent, exception, "Error Log Sample");

logger.LogCritical(LogEvent.ActionEvent, exception, "Critical Log Sample");
```