using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfProject4.Models
{
    public class StonkspizzaDatabase
    {
        public string _connString = ConfigurationManager.ConnectionStrings["ConnStonkspizza"].ConnectionString;

        #region create methodes
        public ulong AddUser(User user)
        {
            ulong insertedUserId = 0;

            using(MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO `users` (`id`, `name`, `email`, `email_verified_at`, `password`, `remember_token`, `created_at`, `updated_at`) VALUES (NULL, @name, @email, NULL, @password, NULL, @date, @date); SELECT LAST_INSERT_ID()";
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    insertedUserId = Convert.ToUInt64(cmd.LastInsertedId);
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }

            return insertedUserId;
        }

        public void AddEmployee(Employee employee)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO `employees` (`id`, `first_name`, `last_name`, `address`, `phone`, `zipcode`, `city`, `country`, `personal_email`, `birth_date`, `burger_service_nummer`, `created_at`, `updated_at`) VALUES (@id, @firstname, @lastname, @address, @phone, @zipcode, @city, NULL, @email, @birthdate, @bsn, @date, @date);";
                    cmd.Parameters.AddWithValue("@id", employee.Id);
                    cmd.Parameters.AddWithValue("@firstname", employee.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", employee.LastName);
                    cmd.Parameters.AddWithValue("@address", employee.Address);
                    cmd.Parameters.AddWithValue("@phone", employee.Phone);
                    cmd.Parameters.AddWithValue("@zipcode", employee.Zipcode);
                    cmd.Parameters.AddWithValue("@city", employee.City);
                    cmd.Parameters.AddWithValue("@email", employee.PersonalEmail);
                    cmd.Parameters.AddWithValue("@birthdate", employee.BirthDate);
                    cmd.Parameters.AddWithValue("@bsn", employee.Bsn);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void AddIngredient(Ingredient ingredient)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO `ingredients` (`id`, `name`, `price`, `quantity`, `unit_id`) VALUES (NULL, @name, @price, @quantity, @unitId);";
                    cmd.Parameters.AddWithValue("@name", ingredient.Name);
                    cmd.Parameters.AddWithValue("@price", ingredient.Price);
                    cmd.Parameters.AddWithValue("@quantity", ingredient.Quantity);
                    cmd.Parameters.AddWithValue("@unitId", ingredient.UnitId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void AddBike(Bike bike)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO `bikes` (`id`, `brand_id`, `model_id`, `employee_id`) VALUES (NULL, @BrandId, @ModelId, @EmployeeId);";
                    cmd.Parameters.AddWithValue("@BrandId", bike.BrandId);
                    cmd.Parameters.AddWithValue("@ModelId", bike.ModelId);
                    cmd.Parameters.AddWithValue("@EmployeeId", bike.EmployeeId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void AddUnit(Unit unit)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO `units` (`id`, `name`) VALUES (NULL, @name);";
                    cmd.Parameters.AddWithValue("@name", unit.Name);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void AddPizza(Pizza pizza)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO `pizzas` (`id`, `name`, `is_custom`, `user_id`) VALUES (NULL, @name, false, NULL);";
                    cmd.Parameters.AddWithValue("@name", pizza.Name);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void AddModel(Bikemodel model)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO `bikemodels` (`id`, `name`) VALUES (NULL, @name);";
                    cmd.Parameters.AddWithValue("@name", model.Name);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void AddBrand(Bikebrand brand)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO `bikebrands` (`id`, `name`) VALUES (NULL, @name);";
                    cmd.Parameters.AddWithValue("@name", brand.Name);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void AddCustomer(Customer customer)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO `customers` (`id`, `first_name`, `last_name`, `address`, `phone`, `zipcode`, `city`, `pizza_points`, `created_at`, `updated_at`) VALUES (@id, @firstname, @lastname, @address, @phone, @zipcode, @city, @pizzapoints, @date, @date);";
                    cmd.Parameters.AddWithValue("@id", customer.Id);
                    cmd.Parameters.AddWithValue("@firstname", customer.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", customer.LastName);
                    cmd.Parameters.AddWithValue("@address", customer.Address);
                    cmd.Parameters.AddWithValue("@phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@zipcode", customer.Zipcode);
                    cmd.Parameters.AddWithValue("@city", customer.City);
                    cmd.Parameters.AddWithValue("@pizzapoints", 10);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        //Voeg koppeling van gebruiker en rol toe
        public void AddUserRole(UserRole userRole)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO user_roles (`id`, `user_id`, `role_id`, `created_at`, `updated_at`) VALUES (NULL, @userId, @roleId, @date, @date);";
                    cmd.Parameters.AddWithValue("@userId", userRole.UserId);
                    cmd.Parameters.AddWithValue("@roleId", userRole.RoleId);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void AddPizzaIngredient(PizzaIngredient pizzaIngredient)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO ingredient_pizza (`id`, `pizza_id`, `ingredient_id`, `quantity`) VALUES (NULL, @pizzaId, @ingredientId, 1);";
                    cmd.Parameters.AddWithValue("@pizzaId", pizzaIngredient.PizzaId);
                    cmd.Parameters.AddWithValue("@ingredientId", pizzaIngredient.IngredientId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void AddOrdertransaction(Ordertransaction ordertransaction)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO ordertransactions (`id`, `order_id`, `user_id`, `to_status_id`, `updated_at`, `created_at`) VALUES (NULL, @orderId, @userId, @statusId, @date, @date);";
                    cmd.Parameters.AddWithValue("@orderId", ordertransaction.OrderId);
                    cmd.Parameters.AddWithValue("@userId", ordertransaction.UserId);
                    cmd.Parameters.AddWithValue("@statusId", ordertransaction.StatusId);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        #endregion

        #region read methodes
        public Order GetOrderById(int id)
        {
            Order order = null;
            DataTable dtUser = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM orders WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtUser.Load(reader);

                    if (dtUser.Rows.Count >= 1)
                    {
                        DataRow row = dtUser.Rows[0];
                        order = new Order()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            DeliveryTime = Convert.ToDateTime(row["deliverytime"]),
                            CustomerId = Convert.ToUInt32(row["customer_id"]),
                            StatusId = Convert.ToUInt32(row["status_id"]),
                            CreatedAt = Convert.ToDateTime(row["created_at"]),
                            UpdatedAt = Convert.ToDateTime(row["updated_at"])
                        };
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return order;
            }
        }
        public Customer GetCustomerById(int id)
        {
            Customer customer = null;
            DataTable dtCustomer = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM customers WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtCustomer.Load(reader);

                    if (dtCustomer.Rows.Count >= 1)
                    {
                        DataRow row = dtCustomer.Rows[0];
                        customer = new Customer()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            FirstName = row["first_name"].ToString(),
                            LastName = row["last_name"].ToString(),
                            Address = row["address"].ToString(),
                            Phone = row["phone"].ToString(),
                            Zipcode = row["zipcode"].ToString(),
                            City = row["city"].ToString(),
                            PizzaPoints = Convert.ToInt32(row["pizza_points"])
                        };
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return customer;
            }
        }
        public User GetUserByEmail(string email)
        {
            User user = null;
            DataTable dtUser = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM users WHERE email = @email";
                    cmd.Parameters.AddWithValue("@email", email);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtUser.Load(reader);

                    if (dtUser.Rows.Count >= 1)
                    {
                        DataRow row = dtUser.Rows[0];
                        user = new User()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            Name = row["name"].ToString(),
                            Email = row["email"].ToString(),
                            Password = row["password"].ToString(),
                        };
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return user;
            }
        }

        public User GetUserByOrder(Order order)
        {
            User user = null;
            DataTable dtUser = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM users WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", order.CustomerId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtUser.Load(reader);

                    if (dtUser.Rows.Count >= 1)
                    {
                        DataRow row = dtUser.Rows[0];
                        user = new User()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            Name = row["name"].ToString(),
                            Email = row["email"].ToString(),
                            Password = row["password"].ToString(),
                        };
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return user;
            }
        }

        public Status GetStatusByOrder(Order order)
        {
            Status status = null;
            DataTable dtStatus = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT status_id, statuses.name FROM orders INNER JOIN statuses ON status_id = statuses.id WHERE orders.id = @id";
                    cmd.Parameters.AddWithValue("@id", order.Id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtStatus.Load(reader);

                    if (dtStatus.Rows.Count >= 1)
                    {
                        DataRow row = dtStatus.Rows[0];
                        status = new Status()
                        {
                            Id = Convert.ToUInt64(row["status_id"]),
                            Name = row["name"].ToString()
                        };
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return status;
            }
        }

        public User GetUserById(ulong id)
        {
            User user = null;
            DataTable dtUser = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM `users` WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtUser.Load(reader);

                    if (dtUser.Rows.Count >= 1)
                    {
                        DataRow row = dtUser.Rows[0];
                        user = new User()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            Name = row["name"].ToString(),
                            Email = row["email"].ToString(),
                            Password = row["password"].ToString(),
                        };
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return user;
            }
        }

        public Ingredient GetIngredientById(ulong id)
        {
            Ingredient ingredient = null;
            DataTable dtIngredient = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM `ingredients` WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtIngredient.Load(reader);

                    if (dtIngredient.Rows.Count >= 1)
                    {
                        DataRow row = dtIngredient.Rows[0];
                        ingredient = new Ingredient()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            Name = row["name"].ToString(),
                            UnitId = 1,
                            Quantity = Convert.ToInt16(row["quantity"]),
                        };
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return ingredient;
            }
        }

        public ObservableCollection<Employee> GetAllEmployees()
        {
            ObservableCollection<Employee> employeeList = new ObservableCollection<Employee>();

            DataTable dtEmployees = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Employees";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtEmployees.Load(reader);

                    foreach (DataRow row in dtEmployees.Rows)
                    {
                        Employee employee = new Employee()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            FirstName = row["first_name"].ToString(),
                            LastName = row["last_name"].ToString(),
                            Address = row["address"].ToString(),
                            Phone = row["phone"].ToString(),
                            Zipcode = row["zipcode"].ToString(),
                            City = row["city"].ToString(),
                            PersonalEmail = row["personal_email"].ToString(),
                            BirthDate = DateTime.Parse(row["birth_date"].ToString()),
                            Bsn = row["burger_service_nummer"].ToString()
                        };
                        employeeList.Add(employee);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return employeeList;
            }
        }

        public ObservableCollection<Customer> GetAllCustomers()
        {
            ObservableCollection<Customer> customerList = new ObservableCollection<Customer>();

            DataTable dtCustomers = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Customers";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtCustomers.Load(reader);

                    foreach (DataRow row in dtCustomers.Rows)
                    {
                        Customer customer = new Customer()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            FirstName = row["first_name"].ToString(),
                            LastName = row["last_name"].ToString(),
                            Address = row["address"].ToString(),
                            Phone = row["phone"].ToString(),
                            Zipcode = row["zipcode"].ToString(),
                            City = row["city"].ToString(),
                            PizzaPoints = Convert.ToInt32(row["pizza_points"]),
                        };
                        customerList.Add(customer);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return customerList;
            }
        }

        public Customer GetCustomerByOrder(Order order)
        {
            Customer customer = null;

            DataTable dtCustomer = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Customers WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", order.CustomerId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtCustomer.Load(reader);

                    if (dtCustomer.Rows.Count >= 1)
                    {
                        DataRow row = dtCustomer.Rows[0];
                        customer = new Customer()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            FirstName = row["first_name"].ToString(),
                            LastName = row["last_name"].ToString(),
                            Address = row["address"].ToString(),
                            Phone = row["phone"].ToString(),
                            Zipcode = row["zipcode"].ToString(),
                            City = row["city"].ToString(),
                            PizzaPoints = Convert.ToInt32(row["pizza_points"])
                        };
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return customer;
            }
        }

        public ObservableCollection<User> GetAllUsers()
        {
            ObservableCollection<User> userList = new ObservableCollection<User>();

            DataTable dtUsers = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Users";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtUsers.Load(reader);

                    foreach (DataRow row in dtUsers.Rows)
                    {
                        User user = new User()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            Name = row["name"].ToString(),
                            Email = row["email"].ToString(),
                            Password = row["password"].ToString()
                        };
                        userList.Add(user);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return userList;
            }
        }

        //Selecteer alle rollen die bedoeld zijn voor medewerkers
        public ObservableCollection<Role> GetAllEmployeeRoles()
        {
            ObservableCollection<Role> roleList = new ObservableCollection<Role>();

            DataTable dtRoles = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Roles WHERE NOT Id = 1";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtRoles.Load(reader);

                    foreach (DataRow row in dtRoles.Rows)
                    {
                        Role role = new Role()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            Name = row["name"].ToString(),
                        };
                        roleList.Add(role);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return roleList;
            }
        }

        //Krijg alle rollen gekoppeld aan een gebruiker
        public ObservableCollection<UserRole> GetUserRolesByUser(User user)
        {
            ObservableCollection<UserRole> rolesList = new ObservableCollection<UserRole>();

            DataTable dtUserRoles = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT user_roles.id, user_roles.user_id, user_roles.role_id, roles.name FROM user_roles INNER JOIN roles ON user_roles.role_id = roles.id WHERE user_roles.user_id = @userId";
                    cmd.Parameters.AddWithValue("@userId", user.Id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtUserRoles.Load(reader);

                    foreach (DataRow row in dtUserRoles.Rows)
                    {
                        UserRole userRole = new UserRole()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            UserId = Convert.ToUInt64(row["user_id"]),
                            RoleId = Convert.ToUInt64(row["role_id"]),
                            Name = row["name"].ToString()
                        };
                        rolesList.Add(userRole);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return rolesList;
        }

        public ObservableCollection<PizzaIngredient> GetPizzaIngredientsByPizza(Pizza pizza)
        {
            ObservableCollection<PizzaIngredient> ingredientsList = new ObservableCollection<PizzaIngredient>();

            DataTable dtPizzaIngredients = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT ingredient_pizza.id, ingredient_pizza.pizza_id, ingredient_pizza.ingredient_id, ingredients.name FROM ingredient_pizza INNER JOIN ingredients ON ingredient_pizza.ingredient_id = ingredients.id WHERE ingredient_pizza.pizza_id = @pizzaId";
                    cmd.Parameters.AddWithValue("@pizzaId", pizza.Id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtPizzaIngredients.Load(reader);

                    foreach (DataRow row in dtPizzaIngredients.Rows)
                    {
                        PizzaIngredient pizzaIngredient = new PizzaIngredient()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            PizzaId = Convert.ToUInt64(row["pizza_id"]),
                            IngredientId = Convert.ToUInt64(row["ingredient_id"]),
                            //Quantity = Convert.ToInt32(row["quantity"]),
                            Name = row["name"].ToString()
                        };
                        ingredientsList.Add(pizzaIngredient);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return ingredientsList;
        }

        public ObservableCollection<Unit> GetAllUnits()
        {
            ObservableCollection<Unit> unitList = new ObservableCollection<Unit>();

            DataTable dtUnits = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Units";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtUnits.Load(reader);

                    foreach (DataRow row in dtUnits.Rows)
                    {
                        Unit unit = new Unit()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            Name = row["name"].ToString()
                        };
                        unitList.Add(unit);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return unitList;
            }
        }

        public ObservableCollection<Pizza> GetAllPizzas()
        {
            ObservableCollection<Pizza> pizzaList = new ObservableCollection<Pizza>();

            DataTable dtPizzas = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM pizzas WHERE is_custom = false";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtPizzas.Load(reader);

                    foreach (DataRow row in dtPizzas.Rows)
                    {
                        Pizza pizza = new Pizza()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            Name = row["name"].ToString()
                        };
                        pizzaList.Add(pizza);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return pizzaList;
            }
        }

        public ObservableCollection<Bikemodel> GetAllModels()
        {
            ObservableCollection<Bikemodel> modelList = new ObservableCollection<Bikemodel>();

            DataTable dtModels = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM bikemodels";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtModels.Load(reader);

                    foreach (DataRow row in dtModels.Rows)
                    {
                        Bikemodel model = new Bikemodel()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            Name = row["name"].ToString()
                        };
                        modelList.Add(model);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return modelList;
            }
        }

        public ObservableCollection<Bikebrand> GetAllBrands()
        {
            ObservableCollection<Bikebrand> brandList = new ObservableCollection<Bikebrand>();

            DataTable dtBrands = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM bikebrands";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtBrands.Load(reader);

                    foreach (DataRow row in dtBrands.Rows)
                    {
                        Bikebrand brand = new Bikebrand()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            Name = row["name"].ToString()
                        };
                        brandList.Add(brand);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return brandList;
            }
        }

        public ObservableCollection<Bike> GetAllBikes()
        {
            ObservableCollection<Bike> bikeList = new ObservableCollection<Bike>();

            DataTable dtBikes = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM bikes";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtBikes.Load(reader);

                    foreach (DataRow row in dtBikes.Rows)
                    {
                        Bike bike = new Bike()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            BrandId = Convert.ToUInt64(row["brand_id"]),
                            ModelId = Convert.ToUInt64(row["model_id"]),
                            EmployeeId = Convert.ToUInt64(row["employee_id"])
                        };
                        bikeList.Add(bike);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return bikeList;
            }
        }

        public ObservableCollection<Ingredient> GetAllIngredients()
        {
            ObservableCollection<Ingredient> ingredientList = new ObservableCollection<Ingredient>();

            DataTable dtIngredients = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Ingredients";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtIngredients.Load(reader);

                    foreach (DataRow row in dtIngredients.Rows)
                    {
                        Ingredient ingredient = new Ingredient()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            Name = row["name"].ToString(),
                            Price = Convert.ToDouble(row["price"]),
                            Quantity = Convert.ToInt32(row["quantity"]),
                            UnitId = Convert.ToUInt64(row["unit_id"])
                        };
                        ingredientList.Add(ingredient);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return ingredientList;
            }

        }

        public ObservableCollection<Order> GetAllOrders()
        {
            ObservableCollection<Order> orderList = new ObservableCollection<Order>();

            DataTable dtOrders = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM orders WHERE status_id != 6 AND status_id != 5";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtOrders.Load(reader);

                    foreach (DataRow row in dtOrders.Rows)
                    {
                        Order order = new Order()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            DeliveryTime = Convert.ToDateTime(row["deliverytime"]),
                            CustomerId = Convert.ToUInt32(row["customer_id"]),
                            StatusId = Convert.ToUInt32(row["status_id"]),
                            CreatedAt = Convert.ToDateTime(row["created_at"]),
                            UpdatedAt = Convert.ToDateTime(row["updated_at"])
                        };
                        orderList.Add(order);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return orderList;
            }
        }

        public ObservableCollection<Order> GetOrdersToBeDelivered()
        {
            ObservableCollection<Order> orderList = new ObservableCollection<Order>();

            DataTable dtOrders = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM orders WHERE status_id = 3";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtOrders.Load(reader);

                    foreach (DataRow row in dtOrders.Rows)
                    {
                        Order order = new Order()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            DeliveryTime = Convert.ToDateTime(row["deliverytime"]),
                            CustomerId = Convert.ToUInt32(row["customer_id"]),
                            StatusId = Convert.ToUInt32(row["status_id"]),
                            CreatedAt = Convert.ToDateTime(row["created_at"]),
                            UpdatedAt = Convert.ToDateTime(row["updated_at"])
                        };
                        orderList.Add(order);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return orderList;
            }
        }

        public ObservableCollection<Orderitem> GetOrderitemsByOrder(Order order)
        {
            ObservableCollection<Orderitem> orderitemList = new ObservableCollection<Orderitem>();

            DataTable dtOrderitems = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT orderitems.id, pizzas.name AS pizzaname, sizes.name AS sizename, sizes.pricefactor AS pricefactor FROM `orderitems` INNER JOIN pizzas ON orderitems.pizza_id = pizzas.id INNER JOIN sizes ON orderitems.size_id = sizes.id WHERE order_id = @OrderId";
                    cmd.Parameters.AddWithValue("@OrderId", order.Id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtOrderitems.Load(reader);

                    foreach (DataRow row in dtOrderitems.Rows)
                    {
                        Orderitem orderitem = new Orderitem()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            PizzaName = row["pizzaname"].ToString(),
                            SizeName = row["sizename"].ToString(),
                            PriceFactor = Convert.ToSingle(row["pricefactor"]),
                        };
                        orderitemList.Add(orderitem);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return orderitemList;
            }
        }

        public ObservableCollection<IngredientOrderitem> GetOrderitemIngredientsByOrderitem(Orderitem orderitem)
        {
            ObservableCollection<IngredientOrderitem> ingredientOrderitemList = new ObservableCollection<IngredientOrderitem>();

            DataTable dtIngredientOrderitem = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT ingredient_orderitem.id, ingredients.id as ingredient_id, ingredients.name, ingredients.price, ingredients.quantity as ingredient_quantity, ingredient_orderitem.quantity as order_quantity, units.name as unit FROM ingredient_orderitem INNER JOIN ingredients ON ingredient_orderitem.ingredient_id = ingredients.id INNER JOIN units ON ingredients.unit_id = units.id WHERE ingredient_orderitem.orderitem_id = @OrderitemId";
                    cmd.Parameters.AddWithValue("@OrderitemId", orderitem.Id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtIngredientOrderitem.Load(reader);

                    foreach (DataRow row in dtIngredientOrderitem.Rows)
                    {
                        IngredientOrderitem ingredientOrderitem = new IngredientOrderitem()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            IngredientId = Convert.ToUInt64(row["ingredient_id"]),
                            Name = row["name"].ToString(),
                            Price = Convert.ToDouble(row["price"]),
                            Quantity = Convert.ToUInt64(row["order_quantity"]),
                            QuantityIngredient = Convert.ToUInt64(row["ingredient_quantity"]),
                            Unit = row["unit"].ToString(),
                            
                        };
                        ingredientOrderitemList.Add(ingredientOrderitem);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return ingredientOrderitemList;
            }
        }

        public ObservableCollection<Status> GetAllStatuses()
        {
            ObservableCollection<Status> statusList = new ObservableCollection<Status>();

            DataTable dtStatuses = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM statuses";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtStatuses.Load(reader);

                    foreach (DataRow row in dtStatuses.Rows)
                    {
                        Status status = new Status()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            Name = row["name"].ToString()
                        };
                        statusList.Add(status);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return statusList;
            }
        }

        public ObservableCollection<Ordertransaction> GetAllOrdertransactions()
        {
            ObservableCollection <Ordertransaction> ordertransactionsList = new ObservableCollection<Ordertransaction>();
            DataTable dtOrdertransactions = new DataTable();
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT ordertransactions.id, ordertransactions.order_id, users.name as user, statuses.name AS status, ordertransactions.updated_at FROM ordertransactions INNER JOIN users ON ordertransactions.user_id = users.id INNER JOIN statuses ON ordertransactions.to_status_id = statuses.id";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtOrdertransactions.Load(reader);

                    foreach (DataRow row in dtOrdertransactions.Rows)
                    {
                        Ordertransaction ordertransaction = new Ordertransaction()
                        {
                            Id = Convert.ToUInt64(row["id"]),
                            OrderId = Convert.ToUInt64(row["order_id"]),
                            User = row["User"].ToString(),
                            Status = row["status"].ToString(),
                            UpdatedAt = Convert.ToDateTime(row["updated_at"])
                        };
                        ordertransactionsList.Add(ordertransaction);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return ordertransactionsList;
            }
        }
        #endregion

        #region update methodes
        public void UpdateUser(User user)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE users SET name = @name, email = @email, updated_at = @date WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void SubtractQuantityFromIngredients(ObservableCollection<IngredientOrderitem> ocIngredients)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                con.Open();
                try
                {
                    foreach (var data in ocIngredients)
                    {
                        MySqlCommand cmd = con.CreateCommand();

                        cmd.CommandText = "UPDATE ingredients SET quantity = @quantity WHERE id = @id";
                        
                        cmd.Parameters.AddWithValue("@quantity", data.QuantityIngredient - data.Quantity);
                        cmd.Parameters.AddWithValue("@id", data.IngredientId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE employees SET first_name = @firstname, last_name = @lastname, address = @address, phone = @phone, zipcode = @zipcode, city = @city, personal_email = @email, burger_service_nummer = @bsn, updated_at = @date WHERE id = @id";
                    cmd.Parameters.AddWithValue("@firstname", employee.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", employee.LastName);
                    cmd.Parameters.AddWithValue("@address", employee.Address);
                    cmd.Parameters.AddWithValue("@phone", employee.Phone);
                    cmd.Parameters.AddWithValue("@zipcode", employee.Zipcode);
                    cmd.Parameters.AddWithValue("@city", employee.City);
                    cmd.Parameters.AddWithValue("@email", employee.PersonalEmail);
                    cmd.Parameters.AddWithValue("@birthdate", employee.BirthDate);
                    cmd.Parameters.AddWithValue("@bsn", employee.Bsn);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id", employee.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE ingredients SET name = @name, price = @price, quantity = @quantity, unit_id = @unitId WHERE id = @id";
                    cmd.Parameters.AddWithValue("@name", ingredient.Name);
                    cmd.Parameters.AddWithValue("@price", ingredient.Price);
                    cmd.Parameters.AddWithValue("@quantity", ingredient.Quantity);
                    cmd.Parameters.AddWithValue("@unitId", ingredient.UnitId);
                    cmd.Parameters.AddWithValue("@id", ingredient.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void UpdateBike(Bike bike)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE bikes SET brand_id = @BrandId, model_id = @ModelId, employee_id = @EmployeeId WHERE id = @id";
                    cmd.Parameters.AddWithValue("@BrandId", bike.BrandId);
                    cmd.Parameters.AddWithValue("@ModelId", bike.ModelId);
                    cmd.Parameters.AddWithValue("@EmployeeId", bike.EmployeeId);
                    cmd.Parameters.AddWithValue("@id", bike.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void UpdateUnit(Unit unit)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE units SET name = @name WHERE id = @id";
                    cmd.Parameters.AddWithValue("@name", unit.Name);
                    cmd.Parameters.AddWithValue("@id", unit.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void UpdateOrderStatus(Order order, Status status)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE orders SET status_id = @statusid, updated_at = @date WHERE id = @id";
                    cmd.Parameters.AddWithValue("@statusid", status.Id);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id", order.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void UpdatePizza(Pizza pizza)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE pizzas SET name = @name WHERE id = @id";
                    cmd.Parameters.AddWithValue("@name", pizza.Name);
                    cmd.Parameters.AddWithValue("@id", pizza.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void UpdateModel(Bikemodel model)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE bikemodels SET name = @name WHERE id = @id";
                    cmd.Parameters.AddWithValue("@name", model.Name);
                    cmd.Parameters.AddWithValue("@id", model.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void UpdateBrand(Bikebrand brand)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE bikebrands SET name = @name WHERE id = @id";
                    cmd.Parameters.AddWithValue("@name", brand.Name);
                    cmd.Parameters.AddWithValue("@id", brand.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE customers SET first_name = @firstname, last_name = @lastname, address = @address, phone = @phone, zipcode = @zipcode, city = @city, pizza_points = @pizzapoints, updated_at = @date WHERE id = @id";
                    cmd.Parameters.AddWithValue("@firstname", customer.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", customer.LastName);
                    cmd.Parameters.AddWithValue("@address", customer.Address);
                    cmd.Parameters.AddWithValue("@phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@zipcode", customer.Zipcode);
                    cmd.Parameters.AddWithValue("@city", customer.City);
                    cmd.Parameters.AddWithValue("@pizzapoints", customer.PizzaPoints);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id", customer.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }
        #endregion

        #region delete methodes
        //Verwijder enkele rol koppeling van gebruiker
        public void DeleteUserRole(UserRole userRole)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM user_roles WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", userRole.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void DeletePizzaIngredient(PizzaIngredient pizzaIngredient)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM ingredient_pizza WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", pizzaIngredient.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        //Verwijder alle gekoppelde rollen van gebruiker
        public void DeleteRolesByUser(User user)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM user_roles WHERE user_id = @id;";
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void DeleteIngedientsByPizza(Pizza pizza)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM ingredient_pizza WHERE pizza_id = @id;";
                    cmd.Parameters.AddWithValue("@id", pizza.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void DeleteEmployee(Employee employee)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM employees WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", employee.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void DeleteCustomer(Customer customer)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM customers WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", customer.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void DeleteUser(User user)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM users WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void DeleteUnit(Unit unit)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM units WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", unit.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void DeletePizza(Pizza pizza)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM pizzas WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", pizza.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void DeleteModel(Bikemodel model)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM bikemodels WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", model.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void DeleteBrand(Bikebrand brand)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM bikebrands WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", brand.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM ingredients WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", ingredient.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void DeleteBike(Bike bike)
        {
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM bikes WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", bike.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }
        #endregion
    }
}
