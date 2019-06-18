Module Module1

    Sub Main()
        Dim MyNumber As New ComplexNumber(3, 5)
        Dim TheirNumber As New ComplexNumber(-2, -4)
        Dim Totalnumber As New ComplexNumber(0, 0)
        Totalnumber = MyNumber - TheirNumber
        Console.WriteLine(Totalnumber.Real)
        Console.WriteLine(Totalnumber.Complex)
        Console.WriteLine(Totalnumber.ModulusArgument)
        Console.ReadKey()
    End Sub

End Module
