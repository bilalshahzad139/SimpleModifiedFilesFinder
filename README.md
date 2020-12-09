# SimpleModifiedFilesFinder

## Working
This simple app finds files modified between a date range and copy those files (with directory structure) to some other location.

app.config contains following settings 
<appSettings>
    <add key="startingPath" value="D:\dockerseries"/>
    <add key="copiedTo" value="D:\MyWork3"/>
    <add key="startDate" value="2020-12-05"/>
    <add key="endDate" value=""/> <!--Leave empty for current date-->
  </appSettings>
  
  
## Use case
If you manually sync your documents from your machine to hard-drive and you don't know how many files you have modified after a date + you don't want to copy paste each & every file manually, you may use this small app.