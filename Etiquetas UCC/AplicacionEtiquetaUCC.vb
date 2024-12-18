﻿Imports System.Collections.Generic
Imports System.IO
Imports System.Text

Public Class AplicacionEtiquetaUCC

    Dim pedidoid As String

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim etiquetaService As New ServicioEtiquetas.EtiquetasSoapClient()
        pedidoid = txtNoPedido.Text
        Try
            Dim result As DataSet = etiquetaService.GetEtiquetaDeCajasByPedidoid(pedidoid)
            If result IsNot Nothing AndAlso result.Tables.Count > 0 Then
                DataGridView1.DataSource = result.Tables(0)
            Else
                MessageBox.Show("No se encontraron etiquetas para el pedido especificado.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al llamar al servicio web: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Application.Exit()
    End Sub
    'NG SUPPLY
    Private Sub btnImprimirTodo_Click(sender As Object, e As EventArgs) Handles btnImprimirTodo.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Seleccione una fila.")
        End If

        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                Dim razonsocial As String = row.Cells("razonsocial").Value.ToString()
                Dim separa_razon_social = razonsocial.Split("*")
                razonsocial = separa_razon_social(0)
                Dim carton As String = row.Cells("carton").Value.ToString()
                Dim sucursal As String = row.Cells("sucursal").Value.ToString()
                Dim oc As String = row.Cells("oc").Value.ToString()
                Dim factura As String = row.Cells("factura").Value.ToString()
                Dim piezas As String = row.Cells("piezas").Value.ToString()
                Dim codigobarras As String = row.Cells("CodigodeBarras").Value.ToString()
                Dim notienda As String = row.Cells("notienda").Value.ToString()
                Dim peso As String = row.Cells("peso").Value.ToString()
                Dim proveedor As String = row.Cells("Proveedor").Value.ToString()
                Dim str1 As String = ""
                Imprimir(peso, razonsocial, notienda, carton, sucursal, oc, factura, piezas, codigobarras, proveedor)
            End If
        Next
    End Sub

    Private Sub btnImprimiSeleccionado_Click(sender As Object, e As EventArgs) Handles btnImprimiSeleccionado.Click

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione una fila.")
        End If

        For Each row As DataGridViewRow In DataGridView1.SelectedRows
            Dim razonsocial As String = row.Cells("razonsocial").Value.ToString()
            Dim separa_razon_social = razonsocial.Split("*")
            razonsocial = separa_razon_social(0)
            Dim notienda As String = row.Cells("notienda").Value.ToString()
            Dim carton As String = row.Cells("carton").Value.ToString()
            Dim sucursal As String = row.Cells("sucursal").Value.ToString()
            Dim oc As String = row.Cells("oc").Value.ToString()
            Dim factura As String = row.Cells("factura").Value.ToString()
            Dim piezas As String = row.Cells("piezas").Value.ToString()
            Dim codigobarras As String = row.Cells("CodigodeBarras").Value.ToString()
            Dim peso As String = row.Cells("peso").Value.ToString()
            Dim proveedor As String = row.Cells("Proveedor").Value.ToString()
            Imprimir(peso, razonsocial, notienda, carton, sucursal, oc, factura, piezas, codigobarras, proveedor)
        Next
    End Sub

    Private Sub Imprimir(peso As String, razonsocial As String, notienda As String, carton As String, sucursal As String, oc As String, factura As String, pieza As String, codigobarras As String, proveedor As String)
        Dim str As String = Interaction.Environ("computername")

        Dim stringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()
        stringBuilder.AppendLine("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3~SD15^JUS^LRN^CI0^XZ")
        stringBuilder.AppendLine("~DGR:NATURAL.GRF,23552,092,")
        stringBuilder.AppendLine(",:::::::::::::::::::::::::::::::::::::U01FPFK01FMFN0hMFC0J0gKFE0R07FPF80K07FLF80,:U03FPFE0I0OFE0K07FhMFE001FgMF80O07FRFC0I03FNF0,")
        stringBuilder.AppendLine("T01FRF8007FOFK03FhOFH07FgNFO01FSFE0H01FOFC,:T07FRFC01FPFC0I0hQFH07FgNFE0M07FSFE0H01FOFE,S01FSFC01FPFC0I0hQFC0FgPFE0L0VF8007FPF80,
            :S01FTF01FPFE0H01FhPFC0FgQFM0VF8007FPF80,:S01FF80N03FF03FE0L03FE0H01FF0Q0HF80gG0HFE0L0HFC3FF0L01FFE0T07FHFC0J03FF80P07FC00FFC0L0HF80,
            S03FE0O03FF03FE0L03FE0H07FF0Q0HF80gG0HFC0L0HFC3FF0L01FF80U07FFE0J03FF0Q07FC00FF80L0HF80,:S03FE0O03FF03FE0L03FE0H07FC0Q0HF80g01FFC0L0HFC3FF0L01FF80U01FHF80I07FF0Q07FC00FF80L0HF80,
            S03FE0P0HF0FFC0L0HFC0H0HFC0Q0HF80g01FFC0L0HFC7FC0L01FF0W03FF80I07FC0Q07FC00FF80L0HF80,:S03FE0P0HF8FFC0L0HFC0H0HF80Q0HF80g01FFC0L0HFC7FC0L07FF0W01FFC0H01FFC0Q07FC03FE0L03FE,
            S0HFC0P0HF8FFC0L0HFC003FF80Q0HF80g01FF0L01FF07FC0L07FF0X07FC0H01FF80Q07FC03FE0L03FE,:S0HFC0P0HF8FFC0L0HFC003FE0R0HF80g07FF0L01FF07FC0L07FF0X07FF0H03FF80Q07FC03FE0L03FE,
            S0HFC0P0HF9FF0L01FF0H07FE0R0HF80g07FF0L01FF1FF80L07FC0X01FF0H03FE0R07FC03FE0L03FE,:S0HFR07F9FF0L01FF0H07FC0R0HF80g07FF0L01FF1FF80K01FFC0X01FF0H0HFE0R07FC07FC0L07FC,
            R01FF0Q07FIFM01FF001FFC0R0HF80g07FC0L07FE1FF80K01FFC0X01FF0H0HF80R07FC07FC0L07FC,:R01FF0Q07FIFM01FF001FF0S0HF80g0HFC0L07FE1FF80K01FFC0Y0HFH01FF80R07FC07FC0L07FC,
            :R01FF0Q07FHFC0L07FE007FE0S0HF80g0HFC0L07FE3FE0L03FF80Y0HFH01FF0S07FC07F0M07FC,R07FE0Q07FHFC0L07FE007FE0S0HFE0Y03FFC0L07FE3FE0L03FF80Y0HFH07FF0S07FC1FF0L01FF0,
            :R07FE0Q07FHFC0L07FE00FF80S0OF80L0OF80L0HF83FE0L03FF80L0KFM01FF007FC0S07FC1FF0L01FF0,R07FE0Q01FHFC0L07FE03FF80S0OF80L0OF80L0HF83FE0L03FF80L0KFM01FF00FFC0S07FC1FF0L01FF0,
            :R07FE0Q01FHF80L0HF803FF0L060L0NFE0M0OF80L0HF8FF80L0HFE0L03FJFM01FF00FF80K030L07FC1FE0L01FE0,R0HF80Q01FHF80L0HF807FF0L060L0NFE0L03FMFE0M0HF0FF80L0HFE0L03FIFC0L01FC03FF80K030L07FC7FE0L03FE0,
            :R0HF80Q01FHF80L0HF807FC0L060L0NFE0L03FMFE0L03FF0FF80L0HFE0L03FIFC0L07FC03FE0L070L07FC7FE0L03FE0,R0HF80Q01FFE0M0HF01FFC0K01E0L0HF80H03FE0L03FF0I03FE0L03FF0FF0M0HFE0L03FIFC0L07FC0FFC0L070L07FC7FE0L03FE0,
            :R0HF80R07FE0L03FF01FF80K01E0L0HF80H03FC0L03FC0I03FE0L03FF1FF0L01FFC0L0KFC0L07FC0FFC0K01F0L07FC7F80L03F80,Q03FE0S07FE0L03FF03FF80K03E0L0HF80H07FC0L07FC0I07FC0L03FC1FF0L01FFC0L0KF80L07F81FF0L01F0L07FCFF80L0HF80,
            :Q03FE0S07FE0L03FF03FE0L03E0L0HF80H07FC0L07FC0I07FC0L07FC1FF0L01FFC0L0KF80K01FF81FF0L03C0L07FCFF80L0HF80,:Q03FE0S07FC0L03FC0FFE0L0FE0L0HF80H07FC0L07FC0I07FC0L07FC1FC0L01FF0M0KF80K01FF87FE0L03C0L07F8FF80L0HF80,
            Q03FE0S07FC0L07FC0FF80L0FE0L0HF8001FF0L01FF0J07FC0L07FC7FC0L07FF0L01FIFE0L01FF8FFE0L0FC0L07FBFF0L03FF,:Q07FC0S07FC0L07FC1FF80K01FE0L0HF8001FF0L01FF0J07F0M07F07FC0L07FF0L01FIF80L03FE0FF80L0FC0L07FIFM03FF,
            Q07FC0S03FC0L07FC1FF0L01FE0L0HF8001FF0L01FF0I01FF0L01FF07FC0L07FF0Y03FE3FF80K03FC0L07FIFM03FF,:Q07FC0S03F0M07F07FF0L07FE0L0HF8001FF0L01FF0I01FF0L01FF07F80L07FE0Y0HFE3FF0L03FC0L07FIFM03FF,
            Q07FC0L040K03F0L01FF07FC0L07FE0L0HF8003FE0L03FE0I01FF0L01FF0FF80L0HFE0X01FFC7FF0L07FC0L07FHFC0L07FC,:P01FF0L01C0K03F0L01FF0FFC0L0HFE0L0HF8003FE0L03FE0I07FE0L03FE0FF80L0HFE0X07FFC7FC0L07FC0L07FHFC0L07FC,
            P01FF0L01C0K03F0L01FF0FF80L0HFE0L0HF8003FE0L03FE0I07FE0L03FE0FF80L0HFE0X0IF1FFC0K01FFC0L07FHFC0L07FC,:P01FF0L01C0L0E0L03FE3FF80K03FFE0L0HF8003FE0L03FE0I07FE0L03FE3FE0M0HF80W03FFE1FF0L01FFC0L07FHFC0L07FC,
            P01FE0L01C0L0E0L03FE3FE0L03FF80L0HF800FF80L0HF80I07FE0L03FE3FE0L03FF80W03FF83FF0L03FFC0L07FHF80K01FF8,:P03FE0L03C0L0E0L03FEFFE0L07FF80L0HF800FF80L0HF80I0HF80L0HF83FE0L03FF80W03FF83FE0L03FFC0L07FHF80K01FF8,
            :P03FE0L03F0L0E0L03FEFFC0L07FF80L0HF800FF80L0HF80I0HF80L0HF83FE0L03FF80X0HF8FFE0L03FFC0L07FHF80K01FF8,P03FE0L03F0L080L0KFC0K01FHF80L0HF800FF0M0HF80I0HF80L0HF8FFC0L07FE0Y0HF8FF80L0IFC0L07FFE0L01FF8,
            :P03F80L03F0T0KFM01FHF80L0HF803FF0L01FF0J0HFN0HF8FFC0L07FE0Y07FIF80L0IFC0L07FFE0L03FE0,P0HF80L0HFU0KFY0HF803FF0L01FF0I03FF0L01FF0FFC0L07FE0Y07FIFY07FFE0L03FE0,
            :P0HF80L0HFU0JFE0X0HF803FF0L01FF0I03FF0L01FF0FFC0L07FE0Y07FIFY07FFE0L03FE0,P0HF80L0HF80R01FIFE0X0HF803FC0L01FF0I03FF0L01FF1FF0L01FFC0L07FIF80L07FHFC0X07FF80L03FE0,
            :O03FF0M0HF80R01FIF80X0HF807FC0L07FC0I03FC0L01FF1FF0L01FFC0L07FIF80L07FHFC0X07FF80L0HFC0,O03FF0L01FF80R01FIF80X0HF807FC0L07FC0I07FC0L07FC1FF0L01FFC0L07FIF80L07FHF80X07FF80L0HFC0,
            :O03FF0L01FF80R01FIFg0HF807FC0L07FC0I07FC0L07FC1FF0L01FFC0L07FIF80L0JF80X07FF80L0HFC0,O03FF0L01FF80R07FHFC0Y0HF81FF80L07F80I07FC0L07FC7FE0L03FF0L01FJF80L0IFE0Y07FF0M0HF,
            :O07FC0L07FFE0R07FHFC0Y0HF81FF80K01FF80I07F80L07FC7FE0L03FF0L01FF3FE0M0IFE0Y07FF0L01FF,:O07FC0L07FFE0R07FHFC0Y0HF81FF80K01FF80H01FF80K01FJFE0L03FF0L01FF3FE0M0IFC0Y07FF0L01FSF80,
            O07FC0L07FFE0R07FHFgG0HF81FF80K01FF80H01FF80K01FJF80L03FF0L01FF3FE0L03FHFC0Y07FF0L01FTF8,:O07FC0L07FFE0Q01FHFE0g0HF83FE0L01FE0I01FF80K01FJF80L0HFE0L03FE3FE0L03FHFgG07FC0L01FTFC,
            N01FF80L0IFE0Q01FHFE0g0HF83FE0L03FE0I01FE0L01FJF80L0HFE0L03FEFFC0L03FHFgG07FC0L07FUF,:N01FF80L0IFE0Q01FHF80L03FJF80L0HF83FE0L03FE0I03FE0L01FJFN0HFE0L03FEFFC0L03FFE0L07FJF80L07FC0L07FUF80,
            N01FF80L0JF80P03FHF80L0LF80L0HF83FE0L03FE0I03FE0M07FHFO0HF80L03F8FFC0L07FFE0L07FJF80L07FC0L07FUF80,:N01FF80L0JF80P03FHFN0LF80L0HF8FFC0L03FC0I03FE0Y03FF80L0HF8FFC0L07FF80L0LF80L07FC0gG0HF80,
            N03FE0L03FIF80P03FHFM01FKF80L0HF8FFC0L0HFC0I03FE0Y03FF80L0HF9FF0M07FF80L0LF80L07FC0gG0HF80,:N03FE0L03FIF80P03FFC0L01FJFE0M0HF8FFC0L0HFC0I03FE0Y07FF80L0HF9FF0M07FE0L03FKF80L07FC0gG0HF80,
            N03FE0L03FE7F80P0IFC0L07FJFE0M0HF8FFC0L0HFC0I03FE0X01FHFN0HF1FF0L01FFC0L03FKF80L07FC0gG0HF80,:N03FC0L03FE7FC0P0IF80L07FC00FE0M0HF9FF0L01FF0J03FE0X03FHFM01FF1FF0L01FFC0L07FF01FF80L07FC0gG0HF80,
            :N0HFC0L0HFC7FC0P0IF80L0HFC00FE0M0HF9FF0L01FF0J01FF80W03FHFM01FF7FE0L01FF0M07FC01FF80L07FC0g03FF,N0HFC0L0HFC3FC0P0HFE0M0HF800FE0M0HF9FF0L01FF0J01FF80V01FIFM01FF7FE0L03FF0M07FC01FF80L07FF0g03FF,
            :N0HFC0L0HFC3FC0O01FFE0L03FF800FE0M0HF9FF0L01FF0J01FFC0V07FHFC0L07FC7FE0L03FE0L01FF801FF80L07FF80Y03FF,N0HFN0HFC3FC0O01FFC0L03FE003FE0M0JFC0L07FE0K07FF0V0JFC0L07FC7F80L03FE0L01FF801FF80L07FFE0Y03FC,
            :M01FF0L01FF03FF0O01FFC0L03FE003FE0M0JFC0L07FE0K07FF80T07FIFC0L07FCFF80L03F80L03FE001FF80L0JF80X07FC,M01FF0L01FF03FF0O01FF0M07FC003FE0M0JFC0L07FE0K03FHFT07FJFC0L07FCFF80L0HF80L03FE001FF80L0KFY07FC,
            :M01FF0L01FF03FF0O07FF0M07FC003FE0M0JFC0L0HFE0L0IFE0Q07FKF80L0HF8FF80L0HFN0HFE001FF80L0KFE0W07FC,M01FF0L07FKF80N0IFM07FFE003FF80K03FIFC0K03FJFE0I07FIFC0M07FMFC0K03FJFE0K03FF80K01FF807FHFC0K03FLF80T01FF8,
            :M01FhFH0gNFC0H01FhTF83FgWF8,:N0hGFE3FgNFJ07FhSF87FgWF8,N0iRF80I0jTF8,:N03FiPF80H03FjRFE0,N0iRFE001FiIFE3FgMFE0,:M01FIF80L01FJFC0K07FLFL03FIFC0M01FLFE0M07FE007FIFN03FF80H03FHF80H03FC0M01FIFE0N0KFJ07FE3FE0I07FJFC0I03FC0181F03FE0,
            M07FHF80N07FHFC0M0KFE0M07FHFQ0KFE0N0HFE007FFE0N03FF80H03FHFJ03FC0O0IFE0N01FHFE0I07FE3FE0I01FJF80I07FE0F81F0FFE0,:M07FFC0O07FFE0N01FIFP0IFQ07FIFP0HF800FHFP03FF80H03FHFJ07FC0O07FFC0O03FFE0I07FE3FF0I01FIFE0I01FFE1F81C0FF80,
            M0IFQ07FF80N01FHFC0O03FF0P01FHF80O0HF803FFE0O03FE0I03FHFJ07F0P01FFC0P0HFE0I0HFE3FF0J07FHF80I03FFE1F81C8FF80,:L03FFC0P07FF0P0IF80O03FF0Q0HFE0P0HF803FF80O0HFE0I0JFJ07F0P01FFC0P0HFE0I0HF81FFC0I07FHFK0IFE1E3908FF80,
            L03FF80P07FC0P0HFE0P03FE0Q0HFC0O03FF807FF0P0HFE0I0IFC0I07F0Q0HFC0P07F80I0HF81FFC0I03FFC0I03FHFE1E3831FF,
            :L03FE0P01FF80P03FC0P01FE0Q0HFC0O03FF007FC0P0HFE0I0IFC0H01FF0Q0HFR07F80I0HF807FF0I03FF80I07FHFC7E38F1FF,:L07FE0I0PF80H01FFC0I0HFC0I0HFE0I01FE0I0IFC0I0HFK0OFH07FC0I07FMFC0I0IFC0H01FE0I07FFC0I0HFJ01FFE0I07F80H03FF807FF0J0FE0I01FIFC7E78F1FF,
            L07FC0I0OFE0I07FFE0I0HFC0H01FHF80H03FE0I0IFC0I0HFJ07FNF01FFC0H01FNFC0H01FHF80H01FE0I07FFC0I0HFJ07FFE0I0HF80H03FE003FF80I0FC0I03FQFC,
            :L07FC0H01FNFE0I07FFE0I0HFJ01FHF80H03F80I0IFC0H01FF0I07FMFC01FF80H01FNFC0H01FHF80H01FE0I0IFC0H01FF0I07FFE0I0HFJ03FE003FF80I070J0SFC,L07FC0H01FNFE0I0IFC0I0HFJ07FFE0I03F80H03FHFC0H01FC0I07FMFC01FF80H03FNFC0H01FHF80H03FE0I0IFC0H01FC0I07FF80I0HFJ07FE0H0HFE0N01FRF8,
            :K01FFC0H01FNFE0I0IFC0H01FF0I07FFE0I03F80H03FHFC0H01FC0I07FMFH01FF80H03FNFJ01FHF80H03F80I0IFJ01FC0I07FF80I0HFJ07FC0H0HFE0N07FQFE0,K01FF0I01FNF80I0IFC0H01FE0I07FFE0I0HF80H03FHFJ01FC0I07FLF8003FF80H03FNFJ07FFE0I03F80H03FHFJ01FC0H01FHF80H03FF0I07FC0H07FF0N0IFC0,
            :K01FF0I07FNF80H03FHFC0H01FE0I07FFE0I0HFJ03FHFJ07FC0I07FLFI03FE0I01FNFJ07FFE0I03F80H03FHFJ07FC0H01FHF80H03FC0I07FC0H07FF0M03FFC,K01FF0I07FNF80H03FHFJ01FE0I0IF80I0HFJ07FHFJ07F80K07FJF8003FE0K07FLFJ07FFE0I0HF80H03FHFJ07F80H01FHFJ03FC0H01FFC0H01FFC0L07FF8,
            :K07FE0I07FNF80H03FHFJ07FE0I0IF80H03FF0I07FFE0I07F80M0JFE003FE0M01FIFE0I07FFE0I0HFJ03FFE0I07F80H03FHFJ03FC0H01FF0I01FFC0K01FFE0,K07FE0I07FFE0H01FF0I03FHFJ07F80I0IF80H03FC0I07FFE0I07F80N01FFE003FE0O07FFE0I0IFC0I0HFJ07FFE0I07F80H03FHFJ07FC0H01FF0J0HFE0K07FFC0,
            :K07FE0I0IFC0I0HFJ07FFE0I07F80H03FHF80H03FC0I07FFE0I0HFC0O0HFE003FF80N03FFE0I0IFC0I0HFJ03FF80I0HF80H03FF80I07F80H01FF0J0HFE0K0IF,:K0HFE0I0IFC0H01FF0I07FFE0I07F80H03FHFJ03FC0H01FHFE0I0IFP03FF003FF80O0HF80I0IFC0H01FF0Q0FE0P01FF80H03FF0J03FF80I03FFE,
            K0HF80I0IFC0H01FF0I07FFE0I0HF80H03FHFJ07FC0H01FHF80I0IFC0N01FF001FHFP0HF80I0IFC0H01FC0P03FE0P01FF80H03FE0J03FF80I07FF8,:K0HF80I0IFC0H01FC0I07FFE0I0FE0I03FHFJ07F80H01FHF80I0KFN01FF001FIFC0M0HF80H03FHFJ01FC0P07FE0P03FF80H03FE0K0HF80H01FHF0,
            K0HF80H03FHFJ01FC0H01FHF80I0FE0I0JFJ07F80H01FHF80H03FLF80J01FF0H07FJFC0K0HF80H03FHFJ07FC0O01FFE0O01FFE0I03FE0K0HF80H01FFC0,:J03FF80H03FHFJ07FC0H01FHF80I0FE0I0IFC0I07F80H03FHF80H03FMFE0I03FF0H03FLFK0HFJ03FHFJ07F80O0IFC0O07FFE0I0HFE0K0HF80H03FF80,
            J03FF0I03FHFJ07F80H01FHF80H03FE0I0IFC0H01FF80H03FHFJ03FNF80H03FE0I0MF80I0HFJ07FHFJ07F80N07FHFC0N03FHFE0I0HFE0J03FF80H03FE,:J03FF0I03FHFJ07F80H01FHF80H03FC0I0IFC0H01FE0I03FHFJ03FNF80H03FE003FMF80I0HFJ07FFC0I07F80H01FNFC0I0OF80I0PFE0I03FE,
            J03FF0I07FFE0I07F80H03FHFJ03FC0H01FHF80H01FE0I03FHFJ07FMFE0I03FE00FNF80H03FF0I07FFC0H01FF80H03FNFJ01FNF80I0PFE0I03FE,:J07FF0I07FFE0I0HF80H03FHFJ03FC0H01FHF80H01FE0I0JFJ07FMFE0I0HFE01FNF80H03FC0I07FFC0H01FE0I03FNFJ01FNF80H03FOFE0I0HFE,
            J07FC0I07FFE0I0FE0I03FHFJ07FC0H01FHF80H03FE0I0IFC0I07FMFE0I0HF807FNFJ03FC0I07FFC0H01FE0I03FNFJ07FNF80H03FOFE0I0HF8,:J07FC0I07FF80I0FE0I03FFC0I07F0I01FFE0I03FC0I0IFC0H01FNFC0I0HF807FNFJ03FC0I07FF80H01FE0I0PFJ07FNFJ03FOFC0I0HF8,
            :J07FC0I07FF80I0FE0I01FF80I07F0J0HFC0I03FC0I0IFJ01FNFK0HF80FNFC0I07FC0I07FE0I03FE0I0LFC7FE0I07FKF1FF0I03FOFC0H01FF8,J07FC0P03FE0P01FF0Q0HFC0P01FF0P01FF80FF80P07FC0P03FC0I0HFE0I07FE0I07FF0I01FF0R0HFC0H01FF0,
            :J07FC0P03FE0P01FF0Q0HFC0P07FE0P07FF00FF80O01FFC0P0HFC0I0HF80I07FE0I0HFE0I01FF0R0HFC0H01FF0,J07FC0P03FE0P03FF0P01FF0Q0HFE0P07FF00FF80O03FFC0O01FFC0H01FF80I0HFE0I0HF80I01FF80Q0HFJ01FF0,
            :J07FF0P03FF80O0IFC0O07FF0P03FFE0O03FFC03FF80O0JFP07FFC0H01FF0J0HF80I0HF80J0HF80Q0HFJ01FF0,J03FF80O0IFC0N07FHFE0N03FHFQ07FFE0O0IFC03FE0O01FIFP0IFJ01FF0J0HF80H03FF80J0HFE0P01FF0I07FC0,
            :J03FFE0O0JFN03FJF80L01FIFP03FHF80N07FHF803FE0N01FJFE0M07FHFJ07FF0J0HF80H03FE0K0IF80O01FF0I07FC0,K0IFE0N0KF80J07FLFC0J03FJFO07FIF80M07FHFE003FE0M01FLFC0K0KFJ07FC0J0HF80H03FE0K03FHF80N01FF0I0HFC0,
            :K0iQFC003FgUFC0J0NFE0K01FgGFC0,K07FgLF87FhFI03FSF87FYFC0J0NFE0L07FgF80,:K01FgKFC01FgYF80I0SFE01FYF80J07FLFC0L03FgF80,:L03FQFE1FPFI0QF8FRFC1FQFE0J0SFI0QF8FMF80J07FLFO0gFE,M07FPF803FMFE0I01FNFC03FPFE007FOFE0K07FPF80I0OFC03FKFC0K01FKFE0N01FXFC,
            :N03FNFC0H01FKFE0L0MFJ07FNF80I0OFC0M03FMFE0L03FKFJ01FIFE0M03FJFR0WFE0,,::")
        stringBuilder.AppendLine("::::::::::::::::::::::::::::::::::^FS")

        stringBuilder.AppendLine("^XA")
        stringBuilder.AppendLine("^MMT")
        stringBuilder.AppendLine("^PW812")
        stringBuilder.AppendLine("^LL1218")
        stringBuilder.AppendLine("^LS0")
        stringBuilder.AppendLine("^FO2,423^GB802,0,5^FS")
        stringBuilder.AppendLine("^FO3,977^GB802,0,5^FS")
        stringBuilder.AppendLine("^FO3,798^GB802,0,6^FS")
        stringBuilder.AppendLine("^FO5,609^GB802,0,5^FS")
        stringBuilder.AppendLine("^FT54,305^A0N,39,38^FH\^FDRAZON SOCIAL: NG SUPPLY S.A. DE C.V. ^FS")
        stringBuilder.AppendLine("^FT54,354^A0N,39,38^FH\^FDCLIENTE: " & razonsocial & " ^FS")
        'stringBuilder.AppendLine("^FT313,303^A0N,45,50^FH\^FDNG SUPPLY SA DE CV^FS")
        stringBuilder.AppendLine("^FT54,405^A0N,39,38^FH\^FDERP ID:^FS")
        stringBuilder.AppendLine("^FT302,405^A0N,45,57^FH\^FD" & pedidoid & "^FS")
        stringBuilder.AppendLine("^FT54,498^A0N,39,38^FH\^FDSUCURSAL: ^FS")
        stringBuilder.AppendLine("^FT54,571^A0N,39,38^FH\^FDNO DE TIENDA:^FS")
        stringBuilder.AppendLine("^FT54,686^A0N,45,45^FH\^FDOC:^FS")
        stringBuilder.AppendLine("^FT54,770^A0N,45,45^FH\^FDFACTURA:^FS")
        stringBuilder.AppendLine("^FT54,873^A0N,45,45^FH\^FDCarton:^FS")
        stringBuilder.AppendLine("^FT54,940^A0N,45,45^FH\^FDPeso:          Kg ^FS")
        stringBuilder.AppendLine("^FT413,913^A0N,45,45^FH\^FDTotal de piezas:  ^FS")
        stringBuilder.AppendLine("^FT32,256^XGR:NATURAL.GRF,1,1^FS")
        stringBuilder.AppendLine("^FT253,496^A0N,45,50^FH\^FD" & sucursal & "^FS")
        stringBuilder.AppendLine("^FT323,568^A0N,51,67^FH\^FD" & notienda & "^FS")
        stringBuilder.AppendLine("^FT139,685^A0N,45,52^FH\^FD" & oc & "^FS")
        stringBuilder.AppendLine("^FT272,770^A0N,45,57^FH\^FD" & factura & "^FS")
        stringBuilder.AppendLine("^FT195,873^A0N,45,50^FH\^FD" & carton & "^FS")
        'stringBuilder.AppendLine("^FT328,873^A0N,45,45^FH\^FD " & peso & "^FS")
        stringBuilder.AppendLine("^FT718,912^A0N,51,67^FH\^FD" & pieza & "^FS")
        stringBuilder.AppendLine("^FT152,942^A0N,45,52^FH\^FD  " & peso & " ^FS")
        stringBuilder.AppendLine("^BY4,3,160^FT110,1164^BCN,,Y,N")
        codigobarras = New String(codigobarras.Where(Function(c) Char.IsDigit(c)).ToArray())
        codigobarras = codigobarras.Trim
        If codigobarras.Length < 20 Then
            Dim suffix As String = "1"
            Dim numZeros As Integer = 20 - codigobarras.Length - suffix.Length
            Dim zeros As String = New String("0"c, numZeros)
            codigobarras &= zeros & suffix
        End If
        stringBuilder.AppendLine("^FD>;" & codigobarras & "^FS")
        stringBuilder.AppendLine("^PQ1,0,1,Y^XZ")

        Dim str1 As String = ""
        str1 = Me.impresoraDB()
        If (str1.Length = 0) Then
            str1 = String.Concat("\\", str, "\zebra")
        End If
        RawPrinter.SendStringToPrinter(str1, stringBuilder.ToString())

    End Sub

    Private Function impresoraDB() As String
        Dim str As String = ""
        Dim str1 As String = String.Concat("C:\EtiquetaUCC", "\impresora.txt")
        Dim str2 As String = ""
        If (File.Exists(str1)) Then
            Dim streamReader As System.IO.StreamReader = New System.IO.StreamReader(str1)
            While streamReader.Peek() <> -1
                str2 = String.Concat(str2, streamReader.ReadLine())
            End While
            str = str2
            streamReader.Close()
            streamReader = Nothing
        End If
        Return str
    End Function

End Class
