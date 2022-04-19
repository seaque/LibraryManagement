[![.Net Framework](https://img.shields.io/badge/DotNet-4.7_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/4.7)

### Uygulama
- Veritabanı Dosyası Dizini: *%appdata%/LibraryManagement*

### Katmanlı Mimari

Çok katmanlı mimari (genellikle n katmanlı mimari olarak adlandırılır) sunum, iş ve veri yönetimi işlevlerinin fiziksel olarak ayrıldığı bir istemci-sunucu mimarisidir. Çok katmanlı mimarinin en yaygın kullanımı üç katmanlı mimaridir. 
- **Sunum katmanı**, son kullanıcının etkileşime geçtiği arayüz ile ilgili bilgileri görüntüler. Sonuçları tarayıcı/istemci katmanına ve ağdaki diğer tüm katmanlara bildirdiği diğer katmanlarla iletişim kurar. 
- **İş katmanı**, bir uygulamanın yetkilendirmesiyle alakalı işlemleri gerçekleştirir. 
- **Veri katmanı**, veri tabanları gibi yapılar ile etkileşime geçerek veriye ulaşımı sağlar. Normalde veri katmanı diğer katmanlarla bağımlılık kurmadan (örneğin bir API aracılığıyla) veriyi üst katmanlara sağlamalıdır.

<p align="center">
<img src="https://github.com/seaque/LibraryManagement/blob/main/img/Katmanl%C4%B1Mimari.png">
</p>
