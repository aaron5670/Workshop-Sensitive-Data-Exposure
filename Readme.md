# Workshop Sensitive Data Exposure
Workshop met Entity Framework Core en SQLite.

## How to install - Microsoft Visual Studio
1. Clone deze repo: ``git clone https://github.com/aaron5670/Workshop-Sensitive-Data-Exposure.git``
2. Configureer de **working directory**:
    1. In **Solution Explorer**, klik met de rechtermuisknop op het project "WebshopDemo" en selecteer **Properties**.
    2. Selecteer het **Debug tab** in het linkerdeelvenster.
    3. Stel **Working directory** in naar het project directory path. **bv: *C:\Users\john\visual-studio\Workshop-Sensitive-Data-Exposure\WebshopDemo***.
    4. Sla de wijzigingen op.
3. Open de **Package Manager Console** via **Tools** > **NuGet Package Managet** > **Package Manager Console** en voer de volgende commands uit:
    1. ``Add-Migration Initial``
    2. ``Update-Database``
