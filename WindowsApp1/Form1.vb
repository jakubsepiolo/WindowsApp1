
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
                .Title = "Y"
                .MajorGrid.LineColor = Color.CornflowerBlue
                .Crossing = 0
                .Minimum = -40
                .Maximum = 40
                .MajorGrid.Enabled = True
                .LineWidth = 2
                .Interval = 5
                .MajorGrid.LineDashStyle = Charting.ChartDashStyle.Solid
            End With
            With .AxisY
                .Title = "X"
                .MajorGrid.LineColor = Color.CornflowerBlue
                .Crossing = 0
                .Minimum = -40
                .Maximum = 40
                .LineWidth = 2
                .Interval = 5
                .MajorGrid.LineDashStyle = Charting.ChartDashStyle.Solid
            End With
        End With



        'specify series plot lines 
        Chart1.Series.Clear()
        Chart1.Series.Add("plot1")
        Chart1.Series("plot1").Color = Color.Red
        Chart1.Series("plot1").ChartType = DataVisualization.Charting.SeriesChartType.Line


        Dim n As Integer = 720 ' number of points

        Dim y As Single
        'For x As Integer = -n To n Step 1
        '    y = Math.Cos((Math.PI * x) / 180)
        '    Chart1.Series("plot1").Points.AddXY(x, y)
        'Next

        Chart1.Series.Add("plot2")
        Chart1.Series("plot2").Color = Color.Blue
        Chart1.Series("plot2").ChartType = DataVisualization.Charting.SeriesChartType.Line
        For x As Integer = 0 To n Step 1
            y = Math.Sin(x / Math.PI)
            Chart1.Series("plot2").Points.AddXY(x, y * 10)
        Next

        Chart1.Series.Add("plot3")

        Chart1.Series("plot3").Color = Color.Gray
        Chart1.Series("plot3").ChartType = DataVisualization.Charting.SeriesChartType.Line

        Chart1.Series.Add("plot4")
        Chart1.Series("plot4").Color = Color.Gray
        Chart1.Series("plot4").ChartType = DataVisualization.Charting.SeriesChartType.Line
        For x As Single = -30 To 30 Step 0.015
            y = Math.Sqrt(60 - x ^ 2)
            Chart1.Series("plot3").Points.AddXY(x, y)
            Chart1.Series("plot4").Points.AddXY(x, -y)
        Next




    End Sub

    Private Sub Chart1_Click_1(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub
End Class
