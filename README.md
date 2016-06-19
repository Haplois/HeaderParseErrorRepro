# Description
A repro for https://github.com/aspnet/Mvc/issues/4883

# Steps to reproduce
1. Download repro, and run it.
2. Open Fiddler, and send this request for error message
  ```
  POST http://localhost:3744/services/authorization HTTP/1.1
  SCRAM-SHA-256: n,n=1,,r=mhtzCDgCf3ZBKUpiYNFctfnFaXYf2MlSuZgc1Oc3DUM=
  Host: localhost:3744
  Content-Length: 0
  Connection: Keep-Alive
  Pragma: no-cache
  ```
  
3. Send this request for successful header parsing
  ```
  POST http://localhost:3744/services/authorization HTTP/1.1
  SCRAM-SHA-256: n,n=1,r=mhtzCDgCf3ZBKUpiYNFctfnFaXYf2MlSuZgc1Oc3DUM=
  Host: localhost:3744
  Content-Length: 0
  Connection: Keep-Alive
  Pragma: no-cache
  ```

# You'll get following exception
```
System.ArgumentOutOfRangeException: Specified argument was out of the range of valid values.
Parameter name: offset
  at Microsoft.Extensions.Primitives.StringSegment..ctor(String buffer, Int32 offset, Int32 length)
  at Microsoft.AspNetCore.Http.Internal.HeaderSegmentCollection.Enumerator.get_Current()
  at Microsoft.AspNetCore.Http.Internal.ParsingHelpers.<GetHeaderSplitImplementation>d__2.MoveNext()
  at System.Linq.Buffer`1..ctor(IEnumerable`1 source)
  at System.Linq.Enumerable.ToArray[TSource](IEnumerable`1 source)
  at Microsoft.AspNetCore.Http.Internal.ParsingHelpers.GetHeaderSplit(IHeaderDictionary headers, String key)
  at Microsoft.AspNetCore.Mvc.ModelBinding.Binders.HeaderModelBinder.BindModelAsync(ModelBindingContext bindingContext)
  at Microsoft.AspNetCore.Mvc.Internal.ControllerArgumentBinder.<BindModelAsync>d__7.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.AspNetCore.Mvc.Internal.ControllerArgumentBinder.<PopulateArgumentsAsync>d__10.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker.<InvokeAllActionFiltersAsync>d__40.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker.<InvokeExceptionFilterAsync>d__39.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
  at Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker.<InvokeAsync>d__32.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler.<InvokeActionAsync>d__8.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.AspNetCore.Builder.RouterMiddleware.<Invoke>d__4.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.AspNetCore.Diagnostics.StatusCodePagesMiddleware.<Invoke>d__3.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
  at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
  at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.<Invoke>d__7.MoveNext()
```
