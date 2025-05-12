Imports System.Data.SqlClient

Public Class Form1
    ' Строка подключения к базе данных
    Dim connectionString As String = "Server=172.20.10.7;Database=InfectionDB;Integrated Security=True;"

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim region As String = txtRegion.Text
        Dim district As String = txtDistrict.Text
        Dim disease As String = txtDisease.Text
        Dim cases As Integer = Integer.Parse(txtCases.Text)
        Dim reportDate As DateTime = dtpDate.Value

        ' Запрос для вставки данных
        Dim query As String = "INSERT INTO InfectionData (Region, District, Disease, Cases, ReportDate) VALUES (@region, @district, @disease, @cases, @date)"

        ' Используем блок Using для корректного управления соединением
        Using connection As New SqlConnection(connectionString)
            Try
                ' Открытие соединения
                connection.Open()

                ' Создание команды
                Using command As New SqlCommand(query, connection)
                    ' Добавление параметров
                    command.Parameters.AddWithValue("@region", region)
                    command.Parameters.AddWithValue("@district", district)
                    command.Parameters.AddWithValue("@disease", disease)
                    command.Parameters.AddWithValue("@cases", cases)
                    command.Parameters.AddWithValue("@date", reportDate)

                    ' Выполнение команды
                    command.ExecuteNonQuery()
                End Using

                ' Сообщение об успешном сохранении данных
                MessageBox.Show("Данные успешно сохранены.")
            Catch ex As Exception
                ' Обработка ошибок
                MessageBox.Show("Ошибка при сохранении данных: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Здесь можно добавить код для инициализации формы, если нужно
    End Sub
End Class
