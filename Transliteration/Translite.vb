Imports System.Text.RegularExpressions

Public Class Translite

    Public Enum TransliterationType
        GOST
        ISO
    End Enum

    Private GOST_CHARS As New Dictionary(Of String, String) From {
        {"Є", "EH"},
        {"№", "#"},
        {"є", "eh"},
        {"А", "A"},
        {"Б", "B"},
        {"В", "V"},
        {"Г", "G"},
        {"Д", "D"},
        {"Е", "E"},
        {"Ё", "JO"},
        {"Ж", "ZH"},
        {"З", "Z"},
        {"И", "I"},
        {"Й", "JJ"},
        {"К", "K"},
        {"Л", "L"},
        {"М", "M"},
        {"Н", "N"},
        {"О", "O"},
        {"П", "P"},
        {"Р", "R"},
        {"С", "S"},
        {"Т", "T"},
        {"У", "U"},
        {"Ф", "F"},
        {"Х", "KH"},
        {"Ц", "C"},
        {"Ч", "CH"},
        {"Ш", "SH"},
        {"Щ", "SHH"},
        {"Ъ", "'"},
        {"Ы", "Y"},
        {"Ь", ""},
        {"Э", "EH"},
        {"Ю", "YU"},
        {"Я", "YA"},
        {"а", "a"},
        {"б", "b"},
        {"в", "v"},
        {"г", "g"},
        {"д", "d"},
        {"е", "e"},
        {"ё", "jo"},
        {"ж", "zh"},
        {"з", "z"},
        {"и", "i"},
        {"й", "jj"},
        {"к", "k"},
        {"л", "l"},
        {"м", "m"},
        {"н", "n"},
        {"о", "o"},
        {"п", "p"},
        {"р", "r"},
        {"с", "s"},
        {"т", "t"},
        {"у", "u"},
        {"ф", "f"},
        {"х", "kh"},
        {"ц", "c"},
        {"ч", "ch"},
        {"ш", "sh"},
        {"щ", "shh"},
        {"ъ", ""},
        {"ы", "y"},
        {"ь", ""},
        {"э", "eh"},
        {"ю", "yu"},
        {"я", "ya"},
        {"«", ""},
        {"»", ""},
        {"—", "-"},
        {" ", "-"}
    }

    Private ISO_CHARS As New Dictionary(Of String, String) From {
        {"Є", "YE"},
        {"Ѓ", "G"},
        {"№", "#"},
        {"є", "ye"},
        {"ѓ", "g"},
        {"А", "A"},
        {"Б", "B"},
        {"В", "V"},
        {"Г", "G"},
        {"Д", "D"},
        {"Е", "E"},
        {"Ё", "YO"},
        {"Ж", "ZH"},
        {"З", "Z"},
        {"И", "I"},
        {"Й", "J"},
        {"К", "K"},
        {"Л", "L"},
        {"М", "M"},
        {"Н", "N"},
        {"О", "O"},
        {"П", "P"},
        {"Р", "R"},
        {"С", "S"},
        {"Т", "T"},
        {"У", "U"},
        {"Ф", "F"},
        {"Х", "X"},
        {"Ц", "C"},
        {"Ч", "CH"},
        {"Ш", "SH"},
        {"Щ", "SHH"},
        {"Ъ", "'"},
        {"Ы", "Y"},
        {"Ь", ""},
        {"Э", "E"},
        {"Ю", "YU"},
        {"Я", "YA"},
        {"а", "a"},
        {"б", "b"},
        {"в", "v"},
        {"г", "g"},
        {"д", "d"},
        {"е", "e"},
        {"ё", "yo"},
        {"ж", "zh"},
        {"з", "z"},
        {"и", "i"},
        {"й", "j"},
        {"к", "k"},
        {"л", "l"},
        {"м", "m"},
        {"н", "n"},
        {"п", "p"},
        {"р", "r"},
        {"с", "s"},
        {"т", "t"},
        {"ф", "f"},
        {"х", "x"},
        {"ц", "c"},
        {"ч", "ch"},
        {"ш", "sh"},
        {"щ", "shh"},
        {"ъ", ""},
        {"ы", "y"},
        {"ь", ""},
        {"э", "e"},
        {"ю", "yu"},
        {"я", "ya"},
        {"«", ""},
        {"»", ""},
        {"—", "-"},
        {" ", "-"}
    }

#Region "Property"

    Private mWithoutSpace As Boolean = True

    ''' <summary>
    ''' Заменять пробелы на символ "-"
    ''' </summary>
    ''' <returns></returns>
    Public Property WithoutSpace As Boolean
        Get
            Return mWithoutSpace
        End Get
        Set(value As Boolean)
            mWithoutSpace = value
            If value Then
                GOST_CHARS(" ") = "-"
                ISO_CHARS(" ") = "-"
            Else
                GOST_CHARS(" ") = " "
                ISO_CHARS(" ") = " "
            End If
        End Set
    End Property

#End Region

    ''' <summary>
    ''' Подготовка текста
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    Private Function ValidateText(text As String) As String
        Dim output As String = Regex.Replace(text, "\s|\.|\(", " ")
        output = Regex.Replace(output, "\s+", " ")
        output = Regex.Replace(output, "[^\s\w\d-]", "")
        output = output.Trim()
        Return output
    End Function

    ''' <summary>
    ''' Перевод на латиницу
    ''' </summary>
    ''' <param name="text">Текст для перевода</param>
    ''' <returns></returns>
    Public Function TransferToLatin(text As String) As String
        Return TransferToLatin(text, TransliterationType.ISO)
    End Function

    ''' <summary>
    ''' Перевод на латиницу
    ''' </summary>
    ''' <param name="text">Текст для перевода</param>
    ''' <param name="type">Тип перевода</param>
    ''' <returns></returns>
    Public Function TransferToLatin(text As String, type As TransliterationType) As String
        Dim output As String = ValidateText(text)
        Dim d As Dictionary(Of String, String) = GetDictonaryByType(type)
        For Each item In d
            output = output.Replace(item.Key, item.Value)
        Next
        Return output
    End Function

    ''' <summary>
    ''' Перевод на кириллицу
    ''' </summary>
    ''' <param name="text">Текст перевода</param>
    ''' <returns></returns>
    Public Function TransferToRus(text As String)
        Return TransferToRus(text, TransliterationType.ISO)
    End Function

    ''' <summary>
    ''' Перевод на кириллицу
    ''' </summary>
    ''' <param name="text">Текст перевода</param>
    ''' <param name="type">Тип перевода</param>
    ''' <returns></returns>
    Public Function TransferToRus(text As String, type As TransliterationType)
        Dim output As String = ValidateText(text)
        Dim d As Dictionary(Of String, String) = GetDictonaryByType(type)
        For Each item In d
            If item.Value IsNot Nothing AndAlso item.Value.Count Then
                output = output.Replace(item.Value, item.Key)
            End If
        Next
        Return output
    End Function

    ''' <summary>
    ''' Возвращает словарь по типу перевода
    ''' </summary>
    ''' <param name="type">Тип перевода</param>
    ''' <returns></returns>
    Private Function GetDictonaryByType(type As TransliterationType) As Dictionary(Of String, String)
        Select Case type
            Case TransliterationType.GOST
                Return GOST_CHARS
            Case TransliterationType.ISO
                Return ISO_CHARS
            Case Else
                Throw New ArgumentException("неизвестный тип словаря", "Translite")
        End Select
    End Function
End Class
