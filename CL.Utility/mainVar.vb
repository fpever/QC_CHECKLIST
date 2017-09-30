Public Class mainVar

    '--- Application path. ---
    Public Shared myPatch As String = My.Application.Info.DirectoryPath
    Public Shared myPatchComps As String = My.Application.Info.DirectoryPath & "\comps"

    '--- Application data path. ---
    'Public Shared myAppData As String = String.Format("{0}\appdata", myPatch)
    'Public Shared myAppData_Comp As String = String.Format("{0}\comp", myAppData)
    Public Shared myAppData As String = String.Format("{0}", myPatch)
    Public Shared myAppData_Comp As String = String.Format("{0}", myAppData)
    Public Shared myAppData_Docform As String = String.Format("{0}", myAppData)

    '--- Application comp extention file name. ---
    Public Shared myCompExtention As String = ".fp"

    Public Shared Function getComp_FileName(ByVal _file As String) As String
        Return String.Format("{0}\comps\{1}{2}", myAppData_Comp, _file, myCompExtention).Trim
    End Function
    Public Shared Function getComp_CustomFileName(ByVal _file As String) As String
        Return String.Format("{0}\comps\{1}", myAppData_Comp, _file).Trim
    End Function

    Public Shared Function getCompPackFile() As String
        Return String.Format("{0}\comp{1}", myAppData_Comp, myCompExtention).Trim
    End Function
    Public Shared Function getCompPackPass() As String
        Return "qc"
    End Function


    'Excel form QC
    Public Shared Q7FlowStatus_ExportForm As String = myAppData_Docform & "\comps\QCStackFlow_formData_8091.xls"

    'Excel form UFDB
    Public Shared UFDBResult_ExportForm As String = myAppData_Docform & "\comps\UFDBResult_fromData_4617.xls"

    'Excel form BS
    Public Shared BSMachineChecklist_ExportForm As String = myAppData_Docform & "\comps\BSMachinePCRchecklist_formData_4648.xls"


    '--- System Phase ---
    Public Enum SYS_PHASE
        A
        B
    End Enum
    Protected Shared _PHASE As SYS_PHASE
    Public Shared Property PHASE As SYS_PHASE
        Get
            Return _PHASE
        End Get
        Set(value As SYS_PHASE)
            _PHASE = value
        End Set
    End Property

    Public Shared ReadOnly Property LOCAL_HOSTNAME As String
        Get
            Return System.Net.Dns.GetHostName
        End Get
    End Property

    Public Shared ReadOnly Property LOCAL_IPADDRESS As String
        Get
            Return System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName).AddressList(0).ToString
        End Get
    End Property





    Public Shared _loadData As System.ComponentModel.DoWorkEventHandler
    Public Shared _loadComplete As System.ComponentModel.RunWorkerCompletedEventHandler
    Public Shared Sub AddDelegate_BackgroundWorker(ByVal _bkWorker As System.ComponentModel.BackgroundWorker)
        With _bkWorker : AddHandler .DoWork, _loadData : AddHandler .RunWorkerCompleted, _loadComplete : End With
    End Sub
    Public Shared Sub ClearDelegate_BackgroundWorker(ByVal _bkWorker As System.ComponentModel.BackgroundWorker)
        With _bkWorker
            RemoveHandler .DoWork, _loadData : RemoveHandler .RunWorkerCompleted, _loadComplete
        End With
    End Sub


End Class
