
using System;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

public class Mahasiswa
{
    public string Nama { get; set; } = "";
    public string NIM { get; set; } = "";
    public int Umur { get; set; }
    public string Jurusan { get; set; } = "";
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== PRAKTIKUM JSON DAN XML ===");

        // 1. Membuat objek mahasiswa
        Mahasiswa mahasiswa = new Mahasiswa
        {
            Nama = "DimasBayu",
            NIM = "24131310031",
            Umur = 21,
            Jurusan = "Teknologi Informasi"
        };

        // 2. Serialisasi objek menjadi JSON
        string jsonString = JsonSerializer.Serialize(
            mahasiswa,
            new JsonSerializerOptions { WriteIndented = true }
        );

        // 3. Menyimpan JSON ke file
        File.WriteAllText("mahasiswa.json", jsonString);
        Console.WriteLine("\nFile JSON berhasil disimpan.");

        // 4. Serialisasi objek menjadi XML
        XmlSerializer serializer =
            new XmlSerializer(typeof(Mahasiswa));

        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, mahasiswa);
            string xmlString = writer.ToString();

            // 5. Menyimpan XML ke file
            File.WriteAllText("mahasiswa.xml", xmlString);
        }

        Console.WriteLine("File XML berhasil disimpan.");

        // 6. Membaca kembali file JSON
        string jsonDibaca = File.ReadAllText("mahasiswa.json");

        // 7. Deserialisasi JSON menjadi objek
        Mahasiswa? hasilJson =
            JsonSerializer.Deserialize<Mahasiswa>(jsonDibaca);

        // 8. Membaca kembali file XML
        string xmlDibaca = File.ReadAllText("mahasiswa.xml");

        // 9. Deserialisasi XML menjadi objek
        using (StringReader reader = new StringReader(xmlDibaca))
        {
            Mahasiswa? hasilXml =
                (Mahasiswa?)serializer.Deserialize(reader);

            // 10. Menampilkan hasil pembacaan
            Console.WriteLine("\n=== HASIL PEMBACAAN JSON ===");
            Console.WriteLine($"Nama     : {hasilJson?.Nama}");
            Console.WriteLine($"NIM      : {hasilJson?.NIM}");
            Console.WriteLine($"Umur     : {hasilJson?.Umur}");
            Console.WriteLine($"Jurusan  : {hasilJson?.Jurusan}");

            Console.WriteLine("\n=== HASIL PEMBACAAN XML ===");
            Console.WriteLine($"Nama     : {hasilXml?.Nama}");
            Console.WriteLine($"NIM      : {hasilXml?.NIM}");
            Console.WriteLine($"Umur     : {hasilXml?.Umur}");
            Console.WriteLine($"Jurusan  : {hasilXml?.Jurusan}");
        }

        Console.WriteLine("\nProgram selesai!");
    }
}
