using System;
using System.Drawing;
using EnciclopediaJuridica.BusinessClass;
using EnciclopediaJuridica.BusinessCollection;


namespace EnciclopediaJuridica.BusinessRule
{
	public class rul_VERBETEUSUARIO
	{

		#region "Variaveis" 

			private  int _VERBETEUSUARIO = -1;
			private  String _NOME = String.Empty;
			private  String _DEFINICAO = String.Empty;
			private  String _BIBLIOGRAFIA = String.Empty;


			private String _mensagem = "";
			private Boolean _NovoRegistro = true;

		#endregion

		#region "Construtures"
 
		public rul_VERBETEUSUARIO()
		{
		}
		public rul_VERBETEUSUARIO( int par_VERBETEUSUARIO)
		{
			try
				{
					this.VERBETEUSUARIO = par_VERBETEUSUARIO;
 
					this.NovoRegistro = !this.Load();
				}
			catch(Exception ex)
				{
					this.mensagem = ex.Message;
				}

		}

		#endregion

		#region "Propriedades"
 
			public  int VERBETEUSUARIO
			{
				get {return _VERBETEUSUARIO;}
				set {_VERBETEUSUARIO = value;}
			}

			public  String NOME
			{
				get {return _NOME;}
				set {_NOME = value;}
			}

			public  String DEFINICAO
			{
				get {return _DEFINICAO;}
				set {_DEFINICAO = value;}
			}

			public  String BIBLIOGRAFIA
			{
				get {return _BIBLIOGRAFIA;}
				set {_BIBLIOGRAFIA = value;}
			}





			public String mensagem
			{
				get { return _mensagem; }
				set { _mensagem = value; }
			}
	
			public Boolean NovoRegistro
			{
				get { return _NovoRegistro; }
				set { _NovoRegistro = value;  }
			}

		#endregion

		#region "Metodos Publicos" 

		public Boolean ValidateInsert()
		{
			try
			{
				// Validacao para o insert e o update
				if (! Validate())
					return false;
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_VERBETEUSUARIO VERBETEUSUARIO = new cls_VERBETEUSUARIO();
				
				VERBETEUSUARIO.VERBETEUSUARIO = this.VERBETEUSUARIO;
				VERBETEUSUARIO.NOME = this.NOME;
				VERBETEUSUARIO.DEFINICAO = this.DEFINICAO;
				VERBETEUSUARIO.BIBLIOGRAFIA = this.BIBLIOGRAFIA;

				this.mensagem="";

				Boolean retorno = VERBETEUSUARIO.Insert();

				this.mensagem = VERBETEUSUARIO.mensagem;

				return retorno;
			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean ValidateUpdate()
		{
			try
			{
				// Validacao para o insert e o update
				if (! Validate())
					return false;
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_VERBETEUSUARIO VERBETEUSUARIO = new cls_VERBETEUSUARIO();
				
				VERBETEUSUARIO.VERBETEUSUARIO = this.VERBETEUSUARIO;
				VERBETEUSUARIO.NOME = this.NOME;
				VERBETEUSUARIO.DEFINICAO = this.DEFINICAO;
				VERBETEUSUARIO.BIBLIOGRAFIA = this.BIBLIOGRAFIA;

				this.mensagem= "";
				
				Boolean retorno = VERBETEUSUARIO.Update();

				this.mensagem = VERBETEUSUARIO.mensagem;

				return retorno;
			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean Validate()
		{
			try
			{

				if (  this.NOME == String.Empty)
				{
					this.mensagem = "O Campo NOME tem que ser preenchido com Texto";
					return false;
				}
				if (  this.DEFINICAO == String.Empty)
				{
					this.mensagem = "O Campo DEFINICAO tem que ser preenchido com Texto";
					return false;
				}
				if (  this.BIBLIOGRAFIA == String.Empty)
				{
					this.mensagem = "O Campo BIBLIOGRAFIA tem que ser preenchido com Texto";
					return false;
				}


				return true;
			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean ValidateDelete()
		{
			try
			{
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_VERBETEUSUARIO VERBETEUSUARIO = new cls_VERBETEUSUARIO();

				
				VERBETEUSUARIO.VERBETEUSUARIO = this.VERBETEUSUARIO;
				VERBETEUSUARIO.NOME = this.NOME;
				VERBETEUSUARIO.DEFINICAO = this.DEFINICAO;
				VERBETEUSUARIO.BIBLIOGRAFIA = this.BIBLIOGRAFIA;


				if (VerifyForeignKeys())
					{

						this.mensagem= "";
				
						Boolean retorno = VERBETEUSUARIO.Delete();

						this.mensagem = VERBETEUSUARIO.mensagem;

						return retorno;
					}	
				else
					{
						return false;
					}

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean ValidateDeleteMasterDetail()
		{
			try
			{
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_VERBETEUSUARIO VERBETEUSUARIO = new cls_VERBETEUSUARIO();
				

				this.mensagem= "";
				
				Boolean retorno = VERBETEUSUARIO.DeleteMasterDetail();

				this.mensagem = VERBETEUSUARIO.mensagem;

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public col_VERBETEUSUARIO GetAll()
		{
			try
			{
				cls_VERBETEUSUARIO VERBETEUSUARIO = new cls_VERBETEUSUARIO();
				col_VERBETEUSUARIO colecao = new col_VERBETEUSUARIO();
				
				VERBETEUSUARIO.VERBETEUSUARIO = this.VERBETEUSUARIO;
				VERBETEUSUARIO.NOME = this.NOME;
				VERBETEUSUARIO.DEFINICAO = this.DEFINICAO;
				VERBETEUSUARIO.BIBLIOGRAFIA = this.BIBLIOGRAFIA;

				System.Data.DataSet ds = VERBETEUSUARIO.GetAll();

                		if (VERBETEUSUARIO.mensagem != String.Empty)
		                {
		                    this.mensagem = VERBETEUSUARIO.mensagem;
		                    return null;
		                }

				for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
				{
					rul_VERBETEUSUARIO item = new rul_VERBETEUSUARIO();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.VERBETEUSUARIO = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DEFINICAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[3].ToString() != String.Empty)
						item.BIBLIOGRAFIA = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[3]).Trim();


					item.NovoRegistro = false;
					colecao.Add(item);
				}
				
				return colecao;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public System.Data.DataSet GetAllInDataSet()
		{
			try
			{
				cls_VERBETEUSUARIO VERBETEUSUARIO = new cls_VERBETEUSUARIO();			
				
				VERBETEUSUARIO.VERBETEUSUARIO = this.VERBETEUSUARIO;
				VERBETEUSUARIO.NOME = this.NOME;
				VERBETEUSUARIO.DEFINICAO = this.DEFINICAO;
				VERBETEUSUARIO.BIBLIOGRAFIA = this.BIBLIOGRAFIA;

				System.Data.DataSet ds = VERBETEUSUARIO.GetAll();

				this.mensagem = VERBETEUSUARIO.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public col_VERBETEUSUARIO FindAll()
		{

			cls_VERBETEUSUARIO VERBETEUSUARIO = new cls_VERBETEUSUARIO();
			col_VERBETEUSUARIO colecao = new col_VERBETEUSUARIO();
				
				VERBETEUSUARIO.VERBETEUSUARIO = this.VERBETEUSUARIO;
				VERBETEUSUARIO.NOME = this.NOME;
				VERBETEUSUARIO.DEFINICAO = this.DEFINICAO;
				VERBETEUSUARIO.BIBLIOGRAFIA = this.BIBLIOGRAFIA;

			System.Data.DataSet ds = VERBETEUSUARIO.FindAll();

               		if (VERBETEUSUARIO.mensagem != String.Empty)
	                {
	                    this.mensagem = VERBETEUSUARIO.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_VERBETEUSUARIO item = new rul_VERBETEUSUARIO();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.VERBETEUSUARIO = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DEFINICAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[3].ToString() != String.Empty)
						item.BIBLIOGRAFIA = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[3]).Trim();


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}


		public col_VERBETEUSUARIO FindAllGrid()
		{

			cls_VERBETEUSUARIO VERBETEUSUARIO = new cls_VERBETEUSUARIO();
			col_VERBETEUSUARIO colecao = new col_VERBETEUSUARIO();
				
				VERBETEUSUARIO.VERBETEUSUARIO = this.VERBETEUSUARIO;
				VERBETEUSUARIO.NOME = this.NOME;
				VERBETEUSUARIO.DEFINICAO = this.DEFINICAO;
				VERBETEUSUARIO.BIBLIOGRAFIA = this.BIBLIOGRAFIA;

			System.Data.DataSet ds = VERBETEUSUARIO.FindAllGrid();

               		if (VERBETEUSUARIO.mensagem != String.Empty)
	                {
	                    this.mensagem = VERBETEUSUARIO.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_VERBETEUSUARIO item = new rul_VERBETEUSUARIO();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.VERBETEUSUARIO = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DEFINICAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[3].ToString() != String.Empty)
						item.BIBLIOGRAFIA = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[3]).Trim();


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}

		public System.Data.DataSet FindAllInDataSet()
		{
			try
			{
				cls_VERBETEUSUARIO VERBETEUSUARIO = new cls_VERBETEUSUARIO();			
				
				VERBETEUSUARIO.VERBETEUSUARIO = this.VERBETEUSUARIO;
				VERBETEUSUARIO.NOME = this.NOME;
				VERBETEUSUARIO.DEFINICAO = this.DEFINICAO;
				VERBETEUSUARIO.BIBLIOGRAFIA = this.BIBLIOGRAFIA;

				System.Data.DataSet ds = VERBETEUSUARIO.FindAll();

				this.mensagem = VERBETEUSUARIO.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public System.Data.DataSet GetAllMasterDetail()
		{
			try
			{
				cls_VERBETEUSUARIO VERBETEUSUARIO = new cls_VERBETEUSUARIO();			
				

				System.Data.DataSet ds = VERBETEUSUARIO.GetAllMasterDetail();

				this.mensagem = VERBETEUSUARIO.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public Boolean Load()
		{
			try
			{
				cls_VERBETEUSUARIO VERBETEUSUARIO = new cls_VERBETEUSUARIO();


				
				VERBETEUSUARIO.VERBETEUSUARIO = this.VERBETEUSUARIO;


				System.Data.DataSet ds = VERBETEUSUARIO.Load();


                		if (VERBETEUSUARIO.mensagem != String.Empty)
		                {
		                    this.mensagem = VERBETEUSUARIO.mensagem;
		                    return false;
		                }


				if( ds.Tables[0].Rows.Count ==1)
				{
										if( ds.Tables[0].Rows[0].ItemArray[0].ToString() != String.Empty)
						this.VERBETEUSUARIO = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

					if( ds.Tables[0].Rows[0].ItemArray[1].ToString() != String.Empty)
						this.NOME = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[1]);

					if( ds.Tables[0].Rows[0].ItemArray[2].ToString() != String.Empty)
						this.DEFINICAO = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[2]);

					if( ds.Tables[0].Rows[0].ItemArray[3].ToString() != String.Empty)
						this.BIBLIOGRAFIA = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[3]);


					this.NovoRegistro = false;
					return true;
				}
				else
				{
					this.mensagem = "Load retornou mais de uma linha";
					this.NovoRegistro = true;
					return false;
				}

			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return false;
			}
		}

		#endregion

		#region "Metodos Privados"

		private Boolean VerifyForeignKeys()
		{
			try
			{
				
				Boolean retorno = true;

				

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		#endregion
	}
}