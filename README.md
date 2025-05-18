✅ 只轉換「指定資料夾底下的第一層子資料夾」名稱中的小寫英文字母為大寫，其餘不變、不遞迴、不亂改符號或數字，也避開 Windows 對大小寫不敏感的陷阱。


✅ Console 輸出時的編碼設定，尤其在處理「日文、中文、韓文」等非 ASCII 字元時容易出現亂碼。
明確設定輸出編碼為 UTF-8
```C#=
console.OutputEncoding = System.Text.Encoding.UTF8;
```