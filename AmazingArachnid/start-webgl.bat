@echo off
color c
start http-server
start ngrok http 8080

pause > nil