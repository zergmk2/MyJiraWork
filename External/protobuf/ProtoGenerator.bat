Set SRC_DIR=%~dp0..\..\MyJiraWork.Core\Utils\
Set DST_DIR=%~dp0..\..\MyJiraWork.Core\Utils\

protoc -I=%SRC_DIR% --csharp_out=%DST_DIR% %SRC_DIR%\*.proto
