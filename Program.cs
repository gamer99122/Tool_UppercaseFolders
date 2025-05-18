// ✅ 請修改為你自己的資料夾路徑
using System.Text.RegularExpressions;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string rootPath = @"G:\尚未分類";

if (!Directory.Exists(rootPath))
{
    Console.WriteLine("❌ 找不到指定資料夾。");
    return;
}

string[] subDirs = Directory.GetDirectories(rootPath);

foreach (string dir in subDirs)
{
    string folderName = Path.GetFileName(dir);

    // ✅ 如果資料夾名稱不含小寫英文字母，略過
    if (!Regex.IsMatch(folderName, "[a-z]"))
    {
        Console.WriteLine($"✅ 已略過：{folderName}");
        continue;
    }
        

    // ✅ 將小寫英文字母轉成大寫，其餘不變
    string newFolderName = Regex.Replace(folderName, "[a-z]", m => m.Value.ToUpper());

    string? parent = Path.GetDirectoryName(dir);
    if (parent == null)
    {
        Console.WriteLine($"⚠ 無法取得 {dir} 的上層目錄，已略過");
        continue;
    }

    string actualPath = Path.Combine(parent, folderName);
    string newPath = Path.Combine(parent, newFolderName);

    // ✅ 比較是否真的需要更名（大小寫不同時才處理）
    if (!actualPath.Equals(newPath, StringComparison.Ordinal))
    {
        try
        {
            Directory.Move(actualPath, newPath);
            Console.WriteLine($"✅ 已重新命名：{folderName} => {newFolderName}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"❌ 錯誤：無法重新命名 {folderName}：{ex.Message}");
        }
    }

    
}

Console.WriteLine("✅ 處理完成。");