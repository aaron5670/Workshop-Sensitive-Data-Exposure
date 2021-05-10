# Workshop Sensitive Data Exposure

Deze workshop laat zien hoe je veilig wachtwoorden van gebruikers kan encrypten (met BCrypt) en opslaan in een database.

Om de workshop eenvoudig te houden is er gebruik gemaakt van Entity Framework Core en SQLite.

## Setup - Microsoft Visual Studio

1. Clone deze repo: ``git clone https://github.com/aaron5670/Workshop-Sensitive-Data-Exposure.git``
2. Configureer de **working directory**:
    1. In **Solution Explorer**, klik met de rechtermuisknop op het project "WebshopDemo" en selecteer **Properties**.
    2. Selecteer het **Debug tab** in het linkerdeelvenster.
    3. Stel **Working directory** in naar het project directory path. **bv: *C:
       \Users\john\visual-studio\Workshop-Sensitive-Data-Exposure\WebshopDemo***.
    4. Sla de wijzigingen op.
3. Open de **Package Manager Console** via **Tools** > **NuGet Package Managet** > **Package Manager Console** en voer
   de volgende commands uit:
    1. ``Add-Migration Initial``
    2. ``Update-Database``

## Workshop

Deze workshop laat zien hoe je veilig gebruikerswachtwoorden kan opslaan in een database.

1. Installeer de volgende NuGet: **BCrypt.Net-Next** ([Link](https://www.nuget.org/packages/BCrypt.Net-Next/)).
2. Vervang de code in de **AddCustomer** methode met het volgende:
   ````c#
   // Hash password
   // Default workFactor is 11 (2,048 iterations)
   var passwordHash = BCrypt.Net.BCrypt.HashPassword(password, 11);
   
   context.Customers.Add(new Customer
   {
       username = username,
       password = passwordHash,
       firstName = firstName,
       lastName = lastName,
       address = address
   });
   ````
3. vervang het if-statement in de methode **Authenticate** met het volgende:
````c#
 if (account == null || !BCrypt.Net.BCrypt.Verify(password, account.password))
 {
     // authentication failed
     return false;
 }
````
4. Done!
