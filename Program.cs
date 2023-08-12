namespace Venta_Celulares
{
	internal class Program
	{
		static void Main(string[] args)
		{

			/////////////////////////////////////////////////////////////////////////////////////////////////////

			Celulares S23ULTRA = Crear("Samsung", "S23 ULTRA", 256, 200, 12, "Qualcomm Snapdragon 8 Gen 2 Adreno 740", false, false, 120, "Negro", 6.5, 5000, 1250);

			Celulares Iphone14ProMax = Crear("Apple", "Iphone 14 Pro max", 1024, 12, 6, "Apple Bionic 2", false, false, 24, "Blanco", 6.4, 4750, 1350);

			Celulares[] ListaDispositivos = new Celulares[] { S23ULTRA, Iphone14ProMax };

			////////////////////////////////////////////////////////////////////////////////////////////////////
			iniciador(ListaDispositivos);







		}
		static void iniciador(Celulares[] ListaDispositivos)
		{
			Menu();
			string _ = Console.ReadLine() ?? "";

			OperacionRealizar(verificaNumero(_, "Menu"), ListaDispositivos);
		}


		static void Menu()
		{
			Console.WriteLine("\n Cell Tech \n");

			Console.WriteLine("\n Menu\n\t1-Comprar.\n\t2-Informaciones.\n\t3-Dispositivos Disponibles.\n\t4-Salir");

			Console.Write("Introduce el Numero de la operacion a realizar: ");
		}


		static void DispositivosDisponibles(Celulares[] Dispositivos)
		{
			int id = 0;
			foreach (Celulares d in Dispositivos)
			{

				Console.WriteLine($"{id} - Marca: {d.Marca} | Modelo: {d.Modelo}");
				id++;
			}
		}
		static int verificaNumero(string valor, string ambito = "")
		{
			bool s = false;
			int value = 0;
			while (!s)
			{

				if (int.TryParse(valor, out value))
				{
					if (ambito != "")
					{
						if (value > 0)
						{
							s = true;
						}
						else
						{
                            Console.WriteLine("\n El numero introducido debe ser diferente de 0.");
                        }
					}
					else
					{
						s = true;

					}
				}
				else
				{
					Console.Write("\n\t:( -._.- Valor Introducido Incorrecto.\n");
					if (ambito != "")
					{
						Menu();
						valor = Console.ReadLine() ?? "";

					}
					else
					{
                        Console.Write("\n Introduce un valor correcto: ");
                        valor = Console.ReadLine() ?? "";

					}

				}
			}
			return value;


		}

		static void OperacionRealizar(int opc, Celulares[] ListaDispositivos)
		{
			switch (opc)
			{
				case 1:
					Comprar(ListaDispositivos);
					iniciador(ListaDispositivos);
					break;
				case 2:
					Informacion(ListaDispositivos);
					iniciador(ListaDispositivos);

					break;
				case 3:
					DispositivosDisponibles(ListaDispositivos);
					iniciador(ListaDispositivos);

					break;
				case 4:
                    Console.WriteLine("\n Esperamos que Vuelva Pronto");
                    break;

				default:
					// controlar esto XD
					Console.WriteLine("\n Operacion Fuera de Rango.");
					iniciador(ListaDispositivos);

					

					break;
			}
		}

		static void Comprar(Celulares[] ListaDispositivos)
		{
			int number = 1;
			bool _ = false;
			while (!_)
			{
				DispositivosDisponibles(ListaDispositivos);

				Console.Write("\n Ingresa el Numero del Dispositivos que deseas comprar: ");
				number = verificaNumero(Console.ReadLine() ?? "");


				if (number <= ListaDispositivos.Length)
				{
					_ = true;
				}
				else
				{
					Console.WriteLine("\n El numero introducido esta fuera de rango.");

				}
			}
			Celulares c = ListaDispositivos[number];
			Console.Write($"Seguro que quieres comprar: {c.Modelo} que cuesta: {c.Precio} USD? (1=Si, 0=No): ");
			if(verificaNumero(Console.ReadLine() ?? "")==1)
			{
				verificarPago(c);

			}
			else
			{
				Console.Clear();
				Menu();
			}


		}
		static void verificarPago(Celulares c)
		{
            Console.Write("\n Introduce el Dinero: ");
            int valor = verificaNumero(Console.ReadLine() ?? "");

			bool s = false;
			while (!s)
			{
				if (valor > c.Precio)
				{
					Console.WriteLine($"\nEspere, Aún le quedan: {valor - c.Precio} Dólares. ");
					Console.WriteLine("-----------------------------------------------------------------");
					Console.WriteLine($"|\tFelicidades acaba de comprar su: {c.Modelo}\t| ");
					Console.WriteLine("-----------------------------------------------------------------");


					s = true;
				}
				else if (valor == c.Precio)
				{

					Console.WriteLine($"\n Felicidades acaba de comprar su: {c.Modelo}\n ");
					s = true;

				}
				else
				{
					Console.Write($"Para comprar: {c.Modelo}, Aún le faltan: {c.Precio-valor}. Favor Introduzca mas Dinero: ");

					valor += verificaNumero(Console.ReadLine() ?? "");

				}

			}

		}


		// OOP
		static Celulares Crear(string marca, string modelo, int almacenamiento, int camara, int ram, string procesador, bool auricular, bool cargador, int velocidadCargar, string color, double tamaño, int bateria, int precio)
		{

			return new Celulares() { Marca = marca, Modelo = modelo, Almacenamiento = almacenamiento, Camara = camara, Ram = ram, Procesador = procesador, Auricular = auricular, Cargador = cargador, VelocidadCarga = velocidadCargar, Color = color, Tamaño = tamaño, Bateria = bateria, Precio = precio };
		}

		static void Informacion(Celulares[] Dispositivos)
		{
			foreach (Celulares c in Dispositivos)
			{
				Console.WriteLine($"\n---------------------------------------\tEspecificaciones del: {c.Marca} {c.Modelo}: \nAlmacenamiento: {c.Almacenamiento}GB \nRam: {c.Ram}GB\nProcesador: {c.Procesador} \nBateria: {c.Bateria} \nVelocidad Carga: {c.VelocidadCarga}W/H \nTamaño: {c.Tamaño} Pulgadas \nCamara Prinicpal: {c.Camara} Pixeles \nColor: {c.Color}");
			}
		}

	}

	class Celulares
	{
		public string Marca { get; set; }
		public int Precio { get; set; }
		public string Modelo { get; set; }
		public int Ram { get; set; }
		public int Bateria { get; set; }
		public string Procesador { get; set; }

		public int Almacenamiento { get; set; }
		public string Color { get; set; }
		public int Camara { get; set; }

		public double Tamaño { get; set; }

		public int VelocidadCarga { get; set; }

		public bool Cargador { get; set; }
		public bool Auricular { get; set; }


		
	}
}