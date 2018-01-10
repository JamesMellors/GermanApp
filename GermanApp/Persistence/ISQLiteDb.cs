using System;
using SQLite;

namespace GermanApp
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();

    }
}
