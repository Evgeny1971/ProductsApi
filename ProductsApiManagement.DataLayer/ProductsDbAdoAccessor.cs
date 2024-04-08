using ProductsApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace ProductsApiManagement.DataLayer
{

public class ProductsDbAdoAccessor //: IProductsApiRepository
{
    private readonly string connectionString;

    public ProductsDbAdoAccessor(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public async Task<List<ShopProduct>> GetAllProducts()
    {
        List<ShopProduct> products = new List<ShopProduct>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("stp_GetAllProducts", connection);
            command.CommandType = CommandType.StoredProcedure;
            await connection.OpenAsync();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                ShopProduct product = MapToShopProduct(reader);
                products.Add(product);
            }
            reader.Close();
        }

        return products;
    }

    public async Task<ShopProduct> CreateShopProduct(ShopProduct shopProduct)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("stp_CreateShopProduct", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Code", shopProduct.Code);
            command.Parameters.AddWithValue("@Name", shopProduct.Name);
            command.Parameters.AddWithValue("@Description", shopProduct.Description);
            command.Parameters.AddWithValue("@StartOfPrice", shopProduct.StartOfPrice);
            command.Parameters.AddWithValue("@Image", shopProduct.Image);

            await connection.OpenAsync();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                shopProduct.ID = Convert.ToInt64(reader["ID"]);
            }
            reader.Close();
        }

        return shopProduct;
    }

    public async Task<ShopProduct> GetShopProductById(long id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("stp_GetShopProductById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", id);

            await connection.OpenAsync();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return MapToShopProduct(reader);
            }
            return null;
        }
    }

    public async Task<bool> DeleteShopProductById(long id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("DeleteShopProductById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", id);

            await connection.OpenAsync();
            int rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }
    }

    public async Task<ShopProduct> UpdateShopProduct(ShopProduct model)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("UpdateShopProduct", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", model.ID);
            command.Parameters.AddWithValue("@Code", model.Code);
            command.Parameters.AddWithValue("@Name", model.Name);
            command.Parameters.AddWithValue("@Description", model.Description);
            command.Parameters.AddWithValue("@StartOfPrice", model.StartOfPrice);
            command.Parameters.AddWithValue("@Image", model.Image);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();

            return await GetShopProductById(model.ID);
        }
    }

    private ShopProduct MapToShopProduct(SqlDataReader reader)
    {
        return new ShopProduct
        {
            ID = Convert.ToInt64(reader["ID"]),
            Code = reader["Code"].ToString(),
            Name = reader["Name"].ToString(),
            Description = reader["Description"].ToString(),
            StartOfPrice = Convert.ToDateTime(reader["StartOfPrice"]),
            Image = reader["Image"].ToString()
        };
    }
}
}