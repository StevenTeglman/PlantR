﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlantRServ.DataAccess
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PlantR")]
	public partial class LinQtoSQLDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPlant(Plant instance);
    partial void UpdatePlant(Plant instance);
    partial void DeletePlant(Plant instance);
    partial void InsertAccount(Account instance);
    partial void UpdateAccount(Account instance);
    partial void DeleteAccount(Account instance);
    partial void InsertPersonalPlant(PersonalPlant instance);
    partial void UpdatePersonalPlant(PersonalPlant instance);
    partial void DeletePersonalPlant(PersonalPlant instance);
    #endregion
		
		public LinQtoSQLDataContext() : 
				base(global::PlantRServ.Properties.Settings.Default.PlantRConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LinQtoSQLDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinQtoSQLDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinQtoSQLDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinQtoSQLDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Plant> Plants
		{
			get
			{
				return this.GetTable<Plant>();
			}
		}
		
		public System.Data.Linq.Table<Account> Accounts
		{
			get
			{
				return this.GetTable<Account>();
			}
		}
		
		public System.Data.Linq.Table<PersonalPlant> PersonalPlants
		{
			get
			{
				return this.GetTable<PersonalPlant>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Plant")]
	public partial class Plant : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _cname;
		
		private string _lname;
		
		private string _imgurl;
		
		private string _description;
		
		private int _sdays;
		
		private EntitySet<PersonalPlant> _PersonalPlants;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OncnameChanging(string value);
    partial void OncnameChanged();
    partial void OnlnameChanging(string value);
    partial void OnlnameChanged();
    partial void OnimgurlChanging(string value);
    partial void OnimgurlChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void OnsdaysChanging(int value);
    partial void OnsdaysChanged();
    #endregion
		
		public Plant()
		{
			this._PersonalPlants = new EntitySet<PersonalPlant>(new Action<PersonalPlant>(this.attach_PersonalPlants), new Action<PersonalPlant>(this.detach_PersonalPlants));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cname", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string cname
		{
			get
			{
				return this._cname;
			}
			set
			{
				if ((this._cname != value))
				{
					this.OncnameChanging(value);
					this.SendPropertyChanging();
					this._cname = value;
					this.SendPropertyChanged("cname");
					this.OncnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lname", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string lname
		{
			get
			{
				return this._lname;
			}
			set
			{
				if ((this._lname != value))
				{
					this.OnlnameChanging(value);
					this.SendPropertyChanging();
					this._lname = value;
					this.SendPropertyChanged("lname");
					this.OnlnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_imgurl", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string imgurl
		{
			get
			{
				return this._imgurl;
			}
			set
			{
				if ((this._imgurl != value))
				{
					this.OnimgurlChanging(value);
					this.SendPropertyChanging();
					this._imgurl = value;
					this.SendPropertyChanged("imgurl");
					this.OnimgurlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sdays", DbType="Int NOT NULL")]
		public int sdays
		{
			get
			{
				return this._sdays;
			}
			set
			{
				if ((this._sdays != value))
				{
					this.OnsdaysChanging(value);
					this.SendPropertyChanging();
					this._sdays = value;
					this.SendPropertyChanged("sdays");
					this.OnsdaysChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Plant_PersonalPlant", Storage="_PersonalPlants", ThisKey="id", OtherKey="pid")]
		public EntitySet<PersonalPlant> PersonalPlants
		{
			get
			{
				return this._PersonalPlants;
			}
			set
			{
				this._PersonalPlants.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PersonalPlants(PersonalPlant entity)
		{
			this.SendPropertyChanging();
			entity.Plant = this;
		}
		
		private void detach_PersonalPlants(PersonalPlant entity)
		{
			this.SendPropertyChanging();
			entity.Plant = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Account")]
	public partial class Account : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _email;
		
		private EntitySet<PersonalPlant> _PersonalPlants;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    #endregion
		
		public Account()
		{
			this._PersonalPlants = new EntitySet<PersonalPlant>(new Action<PersonalPlant>(this.attach_PersonalPlants), new Action<PersonalPlant>(this.detach_PersonalPlants));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Account_PersonalPlant", Storage="_PersonalPlants", ThisKey="id", OtherKey="aid")]
		public EntitySet<PersonalPlant> PersonalPlants
		{
			get
			{
				return this._PersonalPlants;
			}
			set
			{
				this._PersonalPlants.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PersonalPlants(PersonalPlant entity)
		{
			this.SendPropertyChanging();
			entity.Account = this;
		}
		
		private void detach_PersonalPlants(PersonalPlant entity)
		{
			this.SendPropertyChanging();
			entity.Account = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PersonalPlant")]
	public partial class PersonalPlant : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _pid;
		
		private int _aid;
		
		private string _nname;
		
		private System.DateTime _lastwatered;
		
		private System.DateTime _nextwatered;
		
		private int _wduration;
		
		private EntityRef<Account> _Account;
		
		private EntityRef<Plant> _Plant;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnpidChanging(int value);
    partial void OnpidChanged();
    partial void OnaidChanging(int value);
    partial void OnaidChanged();
    partial void OnnnameChanging(string value);
    partial void OnnnameChanged();
    partial void OnlastwateredChanging(System.DateTime value);
    partial void OnlastwateredChanged();
    partial void OnnextwateredChanging(System.DateTime value);
    partial void OnnextwateredChanged();
    partial void OnwdurationChanging(int value);
    partial void OnwdurationChanged();
    #endregion
		
		public PersonalPlant()
		{
			this._Account = default(EntityRef<Account>);
			this._Plant = default(EntityRef<Plant>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pid", DbType="Int NOT NULL")]
		public int pid
		{
			get
			{
				return this._pid;
			}
			set
			{
				if ((this._pid != value))
				{
					if (this._Plant.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnpidChanging(value);
					this.SendPropertyChanging();
					this._pid = value;
					this.SendPropertyChanged("pid");
					this.OnpidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_aid", DbType="Int NOT NULL")]
		public int aid
		{
			get
			{
				return this._aid;
			}
			set
			{
				if ((this._aid != value))
				{
					if (this._Account.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnaidChanging(value);
					this.SendPropertyChanging();
					this._aid = value;
					this.SendPropertyChanged("aid");
					this.OnaidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nname", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string nname
		{
			get
			{
				return this._nname;
			}
			set
			{
				if ((this._nname != value))
				{
					this.OnnnameChanging(value);
					this.SendPropertyChanging();
					this._nname = value;
					this.SendPropertyChanged("nname");
					this.OnnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastwatered", DbType="Date NOT NULL")]
		public System.DateTime lastwatered
		{
			get
			{
				return this._lastwatered;
			}
			set
			{
				if ((this._lastwatered != value))
				{
					this.OnlastwateredChanging(value);
					this.SendPropertyChanging();
					this._lastwatered = value;
					this.SendPropertyChanged("lastwatered");
					this.OnlastwateredChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nextwatered", DbType="Date NOT NULL")]
		public System.DateTime nextwatered
		{
			get
			{
				return this._nextwatered;
			}
			set
			{
				if ((this._nextwatered != value))
				{
					this.OnnextwateredChanging(value);
					this.SendPropertyChanging();
					this._nextwatered = value;
					this.SendPropertyChanged("nextwatered");
					this.OnnextwateredChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_wduration", DbType="Int NOT NULL")]
		public int wduration
		{
			get
			{
				return this._wduration;
			}
			set
			{
				if ((this._wduration != value))
				{
					this.OnwdurationChanging(value);
					this.SendPropertyChanging();
					this._wduration = value;
					this.SendPropertyChanged("wduration");
					this.OnwdurationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Account_PersonalPlant", Storage="_Account", ThisKey="aid", OtherKey="id", IsForeignKey=true)]
		public Account Account
		{
			get
			{
				return this._Account.Entity;
			}
			set
			{
				Account previousValue = this._Account.Entity;
				if (((previousValue != value) 
							|| (this._Account.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Account.Entity = null;
						previousValue.PersonalPlants.Remove(this);
					}
					this._Account.Entity = value;
					if ((value != null))
					{
						value.PersonalPlants.Add(this);
						this._aid = value.id;
					}
					else
					{
						this._aid = default(int);
					}
					this.SendPropertyChanged("Account");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Plant_PersonalPlant", Storage="_Plant", ThisKey="pid", OtherKey="id", IsForeignKey=true)]
		public Plant Plant
		{
			get
			{
				return this._Plant.Entity;
			}
			set
			{
				Plant previousValue = this._Plant.Entity;
				if (((previousValue != value) 
							|| (this._Plant.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Plant.Entity = null;
						previousValue.PersonalPlants.Remove(this);
					}
					this._Plant.Entity = value;
					if ((value != null))
					{
						value.PersonalPlants.Add(this);
						this._pid = value.id;
					}
					else
					{
						this._pid = default(int);
					}
					this.SendPropertyChanged("Plant");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
