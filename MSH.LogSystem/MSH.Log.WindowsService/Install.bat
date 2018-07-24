%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe MSH.Log.WindowsService.exe
Net Start MSHLogService
sc config MSHLogService start= auto