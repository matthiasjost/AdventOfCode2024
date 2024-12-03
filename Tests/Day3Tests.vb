Imports Day3
Imports Xunit

Namespace Tests

    Public Class Day3Tests

        <Fact>
        Sub Test1()
            ' Arrange
            Dim multiplier = New Multiplier()

            ' Act
            Dim result = multiplier.Multiply("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))")

            ' Assert
            Assert.Equal(161, result)
        End Sub

    End Class
End Namespace