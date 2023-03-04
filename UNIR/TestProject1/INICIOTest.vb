﻿Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports WindowsApplication1



'''<summary>
'''Se trata de una clase de prueba para INICIOTest y se pretende que
'''contenga todas las pruebas unitarias INICIOTest.
'''</summary>
<TestClass()> _
Public Class INICIOTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Obtiene o establece el contexto de la prueba que proporciona
    '''la información y funcionalidad para la ejecución de pruebas actual.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Atributos de prueba adicionales"
    '
    'Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
    '
    'Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize para ejecutar código antes de ejecutar cada prueba
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''Una prueba de Login_Load
    '''</summary>
    <TestMethod(), _
     DeploymentItem("Mysql.exe")> _
    Public Sub Login_LoadTest()
        Dim target As INICIO_Accessor = New INICIO_Accessor() ' TODO: Inicializar en un valor adecuado
        Dim sender As Object = Nothing ' TODO: Inicializar en un valor adecuado
        Dim e As EventArgs = Nothing ' TODO: Inicializar en un valor adecuado
        target.Login_Load(sender, e)
        Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.")
    End Sub
End Class
