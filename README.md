# STEPS TO REPRODUCE
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
  
3. send this request for successful header parsing
  ```
  POST http://localhost:3744/services/authorization HTTP/1.1
  SCRAM-SHA-256: n,n=1,r=mhtzCDgCf3ZBKUpiYNFctfnFaXYf2MlSuZgc1Oc3DUM=
  Host: localhost:3744
  Content-Length: 0
  Connection: Keep-Alive
  Pragma: no-cache
  ```
