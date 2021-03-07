# Transliteration VB.NET
Tранслитация кирилицы в латиницу

```Dim kText As String = "Привет мир"
Dim tr As New Transliteration.Translite

' с заменой пробелов

'Кириллица в транслит 
Dim tIso As String = tr.TransferToLatin(kText, Transliteration.Translite.TransliterationType.ISO)
'result: Privet-mir
Dim tGost As String = tr.TransferToLatin(kText, Transliteration.Translite.TransliterationType.GOST)
'result: Privet-mir 

'Транслит в кириллицу
kText = tr.TransferToRus(tIso, Transliteration.Translite.TransliterationType.ISO)
'result: Привет—мир
kText = tr.TransferToRus(tGost, Transliteration.Translite.TransliterationType.GOST)
'result: Привет—мир

' без замены пробелов

kText = "Привет мир"
tr.WithoutSpace = False

'Кириллица в транслит 
tIso = tr.TransferToLatin(kText, Transliteration.Translite.TransliterationType.ISO)
'result: Privet mir
tGost = tr.TransferToLatin(kText, Transliteration.Translite.TransliterationType.GOST)
'result: Privet mir 

'Транслит в кириллицу
kText = tr.TransferToRus(tIso, Transliteration.Translite.TransliterationType.ISO)
'result: Привет мир
kText = tr.TransferToRus(tGost, Transliteration.Translite.TransliterationType.GOST)
'result: Привет мир
