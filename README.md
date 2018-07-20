# Windows Service
Windows Service, Two Thread and Google Maps (GEO)



Windows Service ile 2 Thread, 2 X,Y koordinatları barındıran tablo ve bu işlemlerin sonucunu bir diğer X, Y ve Adres bilgisi  kaydetme için bir tablo. TabloBir'de bulunan X,Y koordinatlarını 1. Thread ile 4 saniyede bir Google GEO Api istekte bulunarak belirtilen X,Y koordinatındaki adres bilgileri ile yeni oluşturulan TabloUc tablo'suna kaydetmekte, TabloIki'de bulunan X,Y koordinatların 2. Thread ile 6 saniyede bir aynı şekilde Google GEO Api istekte bulunur ve belirtilen koordinat'a ait adresleri TabloUc kaydeder. (Not : Veritabanı yerine Singleton Pattern kullanıldı) 

Bütün istekler bittikten sonra Setup'ın kurulduğu dizinde GeoFile.txt dosyası oluşturuyor ve sonucları orada yazıyor.

