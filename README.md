Witam, Aplikacja stworzona jest w środowisku ASP.NET 6.0 więc zaleca się otwarcie jej w programie Viusal Stuio 2022. Po otwarciu CYEOnlineShop.sln proszę o dodanie własnego connection stringa (Server name) z Server Managment Studio do CYEOnlineShop/appsettings.json.

"DefaultConnection": "Server=SERVERNAME;Database=CYEOnlineShop;Trusted_Connection=True;"

Następnie kliknąć Narzędzia -> Menadżer pakietów NuGet -> Kontrola menadzerów pakietów w konsoli należy wpisać updata-database

Po uruchomieniu aplikacji należy dodać przykładowe dane do tabeli. Aplikacja zawiera autoryzację użytkowników z podziałem na role więc po otworzeniu proszę zarejestrować użytkownika oraz zalogować się, aby odblokować pełną funkcjonalność strony 

Gotowe!
