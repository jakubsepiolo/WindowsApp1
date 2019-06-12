
Imports System.Windows.Forms.DataVisualization

Public Class Form1
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Chart1.Titles.Add("Line of x^2") ' specify chart name
        Chart1.ChartAreas.Clear()
        Dim ChartArea1 As New Charting.ChartArea
        ChartArea1 = Chart1.ChartAreas.Add("Default")

        With ChartArea1
            With .AxisX
                .Crossing = 0
                .Minimum = -720
                .Maximum = 720
                .MajorGrid.Enabled = True
                .LineWidth = 2
                .Interval = 180
                .MajorGrid.LineDashStyle = Charting.ChartDashStyle.Dot
            End With
            With .AxisY
                .Crossing = 0
                .Minimum = -5
                .Maximum = 5
                .LineWidth = 2
                .Interval = 1
                .MajorGrid.LineDashStyle = Charting.ChartDashStyle.Dot
            End With
        End With

        With Chart1.ChartAreas("Default")

            .AxisX.Title = "X" ' x label
            .AxisX.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.Title = "Y" 'y label
        End With

        'specify series plot lines 
        Chart1.Series.Clear()
        Chart1.Series.Add("plot1")
        Chart1.Series("plot1").Color = Color.Red
        Chart1.Series("plot1").ChartType = DataVisualization.Charting.SeriesChartType.Line


        Dim n As Integer = 720 ' number of points

        Dim y As Single
        For x As Integer = -n To n Step 1
            y = Math.Cos((Math.PI * x) / 180)
            Chart1.Series("plot1").Points.AddXY(x, y)
        Next

        Chart1.Series.Add("plot2")
        Chart1.Series("plot2").Color = Color.Blue
        Chart1.Series("plot2").ChartType = DataVisualization.Charting.SeriesChartType.Line
        For x As Integer = 1 To n Step 1
            y = Math.Sin((Math.PI * x) / 180)
            Chart1.Series("plot2").Points.AddXY(x, y)
        Next

        Chart1.Series.Add("plot3")
        Chart1.Series("plot3").Color = Color.Gray
        Chart1.Series("plot3").ChartType = DataVisualization.Charting.SeriesChartType.Line
        For x As Integer = 1 To n Step 1
            y = Math.Sqrt(x) / 25
            Chart1.Series("plot3").Points.AddXY(x, y)
        Next

    End Sub
End Class
