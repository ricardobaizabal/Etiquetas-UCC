<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AplicacionEtiquetaUCC
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNoPedido = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnImprimirTodo = New System.Windows.Forms.Button()
        Me.btnImprimiSeleccionado = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.carton = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Factura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Piezas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigodeBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.notienda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.razonsocial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.peso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No de Pedido:"
        '
        'txtNoPedido
        '
        Me.txtNoPedido.Location = New System.Drawing.Point(93, 16)
        Me.txtNoPedido.Name = "txtNoPedido"
        Me.txtNoPedido.Size = New System.Drawing.Size(100, 20)
        Me.txtNoPedido.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(199, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Consultar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnImprimirTodo
        '
        Me.btnImprimirTodo.Location = New System.Drawing.Point(15, 181)
        Me.btnImprimirTodo.Name = "btnImprimirTodo"
        Me.btnImprimirTodo.Size = New System.Drawing.Size(125, 23)
        Me.btnImprimirTodo.TabIndex = 3
        Me.btnImprimirTodo.Text = "Imprimir Todo"
        Me.btnImprimirTodo.UseVisualStyleBackColor = True
        '
        'btnImprimiSeleccionado
        '
        Me.btnImprimiSeleccionado.Location = New System.Drawing.Point(149, 181)
        Me.btnImprimiSeleccionado.Name = "btnImprimiSeleccionado"
        Me.btnImprimiSeleccionado.Size = New System.Drawing.Size(125, 23)
        Me.btnImprimiSeleccionado.TabIndex = 4
        Me.btnImprimiSeleccionado.Text = "Imprimir Seleccionado"
        Me.btnImprimiSeleccionado.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(720, 181)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.carton, Me.Proveedor, Me.Sucursal, Me.oc, Me.Factura, Me.Piezas, Me.CodigodeBarras, Me.notienda, Me.razonsocial, Me.peso})
        Me.DataGridView1.Location = New System.Drawing.Point(15, 42)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(780, 133)
        Me.DataGridView1.TabIndex = 6
        '
        'carton
        '
        Me.carton.DataPropertyName = "carton"
        Me.carton.HeaderText = "Cartón"
        Me.carton.Name = "carton"
        '
        'Proveedor
        '
        Me.Proveedor.DataPropertyName = "proveedor"
        Me.Proveedor.HeaderText = "proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.Visible = False
        '
        'Sucursal
        '
        Me.Sucursal.DataPropertyName = "sucursal"
        Me.Sucursal.HeaderText = "Sucursal"
        Me.Sucursal.Name = "Sucursal"
        Me.Sucursal.Width = 225
        '
        'oc
        '
        Me.oc.DataPropertyName = "oc"
        Me.oc.HeaderText = "O.C."
        Me.oc.Name = "oc"
        '
        'Factura
        '
        Me.Factura.DataPropertyName = "factura"
        Me.Factura.HeaderText = "Factura"
        Me.Factura.Name = "Factura"
        '
        'Piezas
        '
        Me.Piezas.DataPropertyName = "piezas"
        Me.Piezas.HeaderText = "Piezas"
        Me.Piezas.Name = "Piezas"
        '
        'CodigodeBarras
        '
        Me.CodigodeBarras.DataPropertyName = "codigobarras"
        Me.CodigodeBarras.HeaderText = "Código de Barras"
        Me.CodigodeBarras.Name = "CodigodeBarras"
        '
        'notienda
        '
        Me.notienda.DataPropertyName = "notienda"
        Me.notienda.HeaderText = "notienda"
        Me.notienda.Name = "notienda"
        Me.notienda.Visible = False
        '
        'razonsocial
        '
        Me.razonsocial.DataPropertyName = "razonsocial"
        Me.razonsocial.HeaderText = "razonsocial"
        Me.razonsocial.Name = "razonsocial"
        Me.razonsocial.Visible = False
        '
        'peso
        '
        Me.peso.DataPropertyName = "peso"
        Me.peso.HeaderText = "peso"
        Me.peso.Name = "peso"
        Me.peso.Visible = False
        '
        'AplicacionEtiquetaUCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 215)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnImprimiSeleccionado)
        Me.Controls.Add(Me.btnImprimirTodo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtNoPedido)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AplicacionEtiquetaUCC"
        Me.Text = "Aplicación para Etiqueta UCC"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtNoPedido As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnImprimirTodo As Button
    Friend WithEvents btnImprimiSeleccionado As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents carton As DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As DataGridViewTextBoxColumn
    Friend WithEvents Sucursal As DataGridViewTextBoxColumn
    Friend WithEvents oc As DataGridViewTextBoxColumn
    Friend WithEvents Factura As DataGridViewTextBoxColumn
    Friend WithEvents Piezas As DataGridViewTextBoxColumn
    Friend WithEvents CodigodeBarras As DataGridViewTextBoxColumn
    Friend WithEvents notienda As DataGridViewTextBoxColumn
    Friend WithEvents razonsocial As DataGridViewTextBoxColumn
    Friend WithEvents peso As DataGridViewTextBoxColumn
End Class
