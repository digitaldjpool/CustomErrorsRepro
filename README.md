# CustomErrorsRepro

On a default instance of IIS, customErrors mode is RemoteOnly:  
https://msdn.microsoft.com/en-us/library/h0hfz6fc(v=vs.100).aspx

(This doesn't seem to conflict with a web app using httpErrors mode, but if customErrors is set to "On" then it steals handling from httpErrors.)
Our Azure App Service plan seems to have turned on customErrors on June 10 without any notice.  Here is a repro-

This web app throws an intentional error on "/"  (home/index)
On a default IIS instance such as an on prem server, you will be redirected by the httpError section and see the 'good' error page  /error/http500
On our Azure App Service Plan you will not.  It appears that in Azure, customErrors is set to "On", and the original error now gets lost as Azure IIs now tries to load a default /error view which does not exist
You can see the logged error messages and the customErrors mode we read during each error at /home/memorylog
