Imports System.Web.Http

Public Class corsConfig
Public Shared Sub Register(config As HttpConfiguration)
        ' New code
        config.EnableCors()

        config.Routes.MapHttpRoute(name:="DefaultApi", routeTemplate:="api/{controller}/{id}", defaults:=New With { _
            Key .id = RouteParameter.[Optional] _
        })
    End Sub
End Class
