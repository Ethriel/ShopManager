
## For testing you can use:
1. DB backups located at **ShopManager.Database\Db backups**. Select a file corresponding to version of your SSMS:
    - **2022** (you can use either *.bak file* or run *SQL script*);
    - **2019** (run corresponding *SQL script*);
    - **2016** (run corresponding *SQL script*);
    - **2008-R2** (run corresponding *SQL script*).
2. In **appsettings.json** config file, located at **ShopManager.Server**, you can:
    - Change **IsFirstRun** to **true** if you want to migrate DB on first run of an app.
        Note that you can keep it as **false**, but then you will need to migrate database manually using **Update-Database** command in the terminal;
    - Change **CreateTestData** to **true** if you want to create test data;
    Please, note that if you set any of those settings to **true**, run the app and closed it, you need to set them back to **false** before next run if you want to avoid duplicates in your DB.