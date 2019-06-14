
Imports System.Windows.Forms.DataVisualization

Public Class Form1
    Private ChartCount As Integer
    Public Sub CreateCircle(ByVal CentreX As Integer, ByVal CentreY As Integer, ByVal Radius As Single)
        Chart1.Series.Add("plot" & ChartCount)
        Chart1.Series.Add("plot" & ChartCount + 1)

        Chart1.Series("plot" & ChartCount).Color = Color.Red
        Chart1.Series("plot" & ChartCount + 1).Color = Color.Red

        Chart1.Series("plot" & ChartCount).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series("plot" & ChartCount + 1).ChartType = DataVisualization.Charting.SeriesChartType.Line

        Dim y As Single = 0

        For x As Single = -Radius To Radius Step 0.015
            y = Math.Sqrt((Radius ^ 2) - x ^ 2)
            Chart1.Series("plot" & ChartCount).Points.AddXY(x + CentreX, y + CentreY)
            Chart1.Series("plot" & ChartCount + 1).Points.AddXY(x + CentreX, -y + CentreY)
        Next

        ChartCount += 2

    End Sub

    Public Sub CreateLine(ByVal Gradient As Single, ByVal Intercept As Single)
        Chart1.Series.Add("plot" & ChartCount)
        Chart1.Series("plot" & ChartCount).Color = Color.Gray
        Chart1.Series("plot" & ChartCount).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Dim y As Single = 0

        For x As Single = Chart1.ChartAreas.FindByName("Default").AxisX.Minimum To Chart1.ChartAreas.FindByName("Default").AxisX.Maximum Step 1
            y = Gradient * x + Intercept
            Chart1.Series("plot" & ChartCount).Points.AddXY(x, y)
        Next
        ChartCount += 1
    End Sub

    Public Sub CreateQuadratic(ByVal a As Single, ByVal b As Single, ByVal Intercept As Single)
        Chart1.Series.Add("plot" & ChartCount)
        Chart1.Series("plot" & ChartCount).Color = Color.Blue
        Chart1.Series("plot" & ChartCount).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Dim y As Single = 0

        For x As Single = Chart1.ChartAreas.FindByName("Default").AxisX.Minimum To Chart1.ChartAreas.FindByName("Default").AxisX.Maximum Step 0.25
            y = a * x ^ 2 + b * x + Intercept
            Chart1.Series("plot" & ChartCount).Points.AddXY(x, y)
        Next
        ChartCount += 1
    End Sub


    Public Sub CreateCubic(ByVal a As Single, ByVal b As Single, ByVal c As Single, ByVal Intercept As Single)
        Chart1.Series.Add("plot" & ChartCount)
        Chart1.Series("plot" & ChartCount).Color = Color.Yellow
        Chart1.Series("plot" & ChartCount).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Dim y As Single = 0

        For x As Single = Chart1.ChartAreas.FindByName("Default").AxisX.Minimum To Chart1.ChartAreas.FindByName("Default").AxisX.Maximum Step 0.25
            y = a * x ^ 3 + b * x ^ 2 + c * x + Intercept
            Chart1.Series("plot" & ChartCount).Points.AddXY(x, y)
        Next
        ChartCount += 1
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Chart1.Titles.Add("Line of x^2") ' specify chart name
        Chart1.ChartAreas.Clear()
        Dim ChartArea1 As New Charting.ChartArea
        ChartArea1 = Chart1.ChartAreas.Add("Default")
        Chart1.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
        Chart1.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
        Chart1.Annotations.Add(New Charting.CalloutAnnotation)
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
        CreateCircle(Int(Rnd() * 10), Int(Rnd() * 10), 30)
        CreateCircle(0, 16, 25)
        CreateLine(3, -5)
        CreateQuadratic(3, 3, -15)
        CreateQuadratic(-1, -5, 15)
        CreateCubic(1, 0, 0, 0)

        Chart1.ChartAreas(0).AxisX.Maximum = Chart1.ChartAreas(0).AxisX.MaximumAutoSize
        Chart1.ChartAreas(0).AxisY.Maximum = Chart1.ChartAreas(0).AxisY.MaximumAutoSize

        ''specify series plot lines 
        'Chart1.Series.Clear()
        'Chart1.Series.Add("plot1")
        'Chart1.Series("plot1").Color = Color.Red
        'Chart1.Series("plot1").ChartType = DataVisualization.Charting.SeriesChartType.Line


        'Dim n As Integer = 720 ' number of points

        'Dim y As Single
        ''For x As Integer = -n To n Step 1
        ''    y = Math.Cos((Math.PI * x) / 180)
        ''    Chart1.Series("plot1").Points.AddXY(x, y)
        ''Next

        'Chart1.Series.Add("plot2")
        'Chart1.Series("plot2").Color = Color.Blue
        'Chart1.Series("plot2").ChartType = DataVisualization.Charting.SeriesChartType.Line
        'For x As Integer = 0 To n Step 1
        '    y = Math.Sin(x / Math.PI)
        '    Chart1.Series("plot2").Points.AddXY(x, y * 10)
        'Next

        'Chart1.Series.Add("plot3")

        'Chart1.Series("plot3").Color = Color.Gray
        'Chart1.Series("plot3").ChartType = DataVisualization.Charting.SeriesChartType.Line

        'Chart1.Series.Add("plot4")
        'Chart1.Series("plot4").Color = Color.Gray
        'Chart1.Series("plot4").ChartType = DataVisualization.Charting.SeriesChartType.Line
        'For x As Single = -50 To 50 Step 0.015
        '    y = Math.Sqrt(2500 - x ^ 2)
        '    Chart1.Series("plot3").Points.AddXY(x, y)
        '    Chart1.Series("plot4").Points.AddXY(x, -y)
        'Next




    End Sub
    Private Sub Chart1_MouseEnter(sender As Object, e As EventArgs) Handles Chart1.MouseEnter
        Chart1.Focus()
    End Sub


    'Private Sub Chart1_MouseMove(sender As Object, e As MouseEventArgs) Handles Chart1.MouseMove
    '    Try
    '        Dim result As Charting.HitTestResult = Chart1.HitTest(e.X, e.Y)

    '        If result.ChartElementType = Charting.ChartElementType.DataPoint Then
    '            Chart1.Series(1).Points(result.PointIndex).XValue.ToString()

    '            Dim thisPt As New PointF(Math.Round(CSng(Chart1.Series(1).Points(result.PointIndex).XValue), 2),
    '                                    Math.Round(CSng(Chart1.Series(1).Points(result.PointIndex).YValues(0)), 2))
    '            Dim ta As New Charting.CalloutAnnotation
    '            With ta
    '                .AnchorDataPoint = Chart1.Series(1).Points(result.PointIndex)
    '                .X = thisPt.X + 1
    '                .Y = thisPt.Y + 1
    '                .Text = thisPt.ToString
    '                .CalloutStyle = Charting.CalloutStyle.SimpleLine
    '                .ForeColor = Color.Red
    '                .Font = New Font("Tahoma", 12, FontStyle.Bold)
    '            End With
    '            Chart1.Annotations(0) = ta
    '            Chart1.Invalidate()
    '        End If
    '    Catch ex As ArgumentOutOfRangeException
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub
    Private Sub Chart1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Chart1.MouseClick

        Try
            Dim ht As DataVisualization.Charting.HitTestResult = Chart1.HitTest(e.X, e.Y)
            For i = 0 To ChartCount
                If Not ht.ChartElementType = Charting.ChartElementType.Nothing Then
                    Dim xx As Double = ht.ChartArea.AxisX.PixelPositionToValue(e.X)
                    Dim yy As Double = ht.ChartArea.AxisY.PixelPositionToValue(e.Y)
                    If xx >= Chart1.ChartAreas(0).AxisX.Minimum And xx <= Chart1.ChartAreas(0).AxisX.Maximum And
                        yy >= Chart1.ChartAreas(0).AxisY.Minimum And yy <= Chart1.ChartAreas(0).AxisY.Maximum Then

                        Me.Text = xx.ToString & "   " & yy.ToString
                        Dim ta As New Charting.CalloutAnnotation
                        With ta
                            .AnchorDataPoint = Chart1.Series(i).Points(ht.PointIndex)
                            Dim thisPt As New PointF(Math.Round(CSng(Chart1.Series(i).Points(ht.PointIndex).XValue), 2),
                                                        Math.Round(CSng(Chart1.Series(i).Points(ht.PointIndex).YValues(0)), 2))
                            .X = thisPt.X + 1
                            .Y = thisPt.Y + 1
                            .Text = thisPt.ToString
                            .CalloutStyle = Charting.CalloutStyle.SimpleLine
                            .ForeColor = Color.Red
                            .Font = New Font("Tahoma", 12, FontStyle.Bold)
                        End With
                        Chart1.Annotations(0) = ta
                        Chart1.Invalidate()
                    End If
                End If
            Next

        Catch ex As ArgumentOutOfRangeException

        End Try

    End Sub


    Private Sub Chart1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Chart1.MouseWheel

        Try
            With Chart1
                If (e.Delta < 0) Then
                    .ChartAreas(0).AxisX.ScaleView.ZoomReset()
                    .ChartAreas(0).AxisY.ScaleView.ZoomReset()
                End If
                If (e.Delta > 0) Then
                    Dim xMin As Double = .ChartAreas(0).AxisX.ScaleView.ViewMinimum
                    Dim xMax As Double = .ChartAreas(0).AxisX.ScaleView.ViewMaximum
                    Dim yMin As Double = .ChartAreas(0).AxisY.ScaleView.ViewMinimum
                    Dim yMax As Double = .ChartAreas(0).AxisY.ScaleView.ViewMaximum
                    Dim posXStart As Double = (.ChartAreas(0).AxisX.PixelPositionToValue(e.Location.X) - ((xMax - xMin) / 4))
                    Dim posXFinish As Double = (.ChartAreas(0).AxisX.PixelPositionToValue(e.Location.X) + ((xMax - xMin) / 4))
                    Dim posYStart As Double = (.ChartAreas(0).AxisY.PixelPositionToValue(e.Location.Y) - ((yMax - yMin) / 4))
                    Dim posYFinish As Double = (.ChartAreas(0).AxisY.PixelPositionToValue(e.Location.Y) + ((yMax - yMin) / 4))
                    .ChartAreas(0).AxisX.ScaleView.Zoom(posXStart, posXFinish)
                    .ChartAreas(0).AxisY.ScaleView.Zoom(posYStart, posYFinish)
                End If
            End With


        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Chart1_Click_1(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub
End Class
