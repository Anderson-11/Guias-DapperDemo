﻿using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DapperDemo
{
    public partial class Form1 : Form
    {
        CustomerRepository customerR = new CustomerRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var cliente = customerR.ObtenerTodo();
            dgvCustomers.DataSource = cliente;
        }

        private void btnObtenerID_Click(object sender, EventArgs e)
        {
            var cliente = customerR.ObtenerPorID(tboxObtenerID.Text);
            dgvCustomers.DataSource = new List<Customers> { cliente };
            tboxObtenerID.Text = "";
            ObtenerDatos(cliente);
            txbCustomerId.Enabled = false;
        }

        private void ObtenerDatos(Customers customer)
        {
            txbCustomerId.Text = customer.CustomerID;
            txbCompanyName.Text = customer.CompanyName;
            txbContactName.Text = customer.ContactName;
            txbContactTitle.Text = customer.ContactTitle;
            txbAddress.Text = customer.Address;
        }

        private Customers CrearCliente()
        {
            var nuevo = new Customers
            {
                CustomerID = txbCustomerId.Text,
                CompanyName = txbCompanyName.Text,
                ContactName = txbContactName.Text,
                ContactTitle = txbContactTitle.Text,
                Address = txbAddress.Text
            };
            return nuevo;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var nuevoCliente = CrearCliente();
            var insertado = customerR.InsertarCliente(nuevoCliente);
            MessageBox.Show($"Registros Insertados {insertado}");
            Limpiar();
        }

        private void Limpiar()
        {
            txbCustomerId.Text = "";
            txbCompanyName.Text = "";
            txbContactName.Text = "";
            txbContactTitle.Text = "";
            txbAddress.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminados = customerR.EliminarCliente(txbCustomerId.Text);

            if (eliminados == 1)
            {
                MessageBox.Show("Eliminado");
                Limpiar();
                txbCustomerId.Enabled = true;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var clienteActualizado = CrearCliente();
            var actualizados = customerR.AcctualizarCliente(clienteActualizado);
            var cliente = customerR.ObtenerPorID(clienteActualizado.CustomerID);
            dgvCustomers.DataSource = new List<Customers> { cliente };


            MessageBox.Show($"Se actualizo a {actualizados} , {clienteActualizado.CustomerID}");
            Limpiar();
            txbCustomerId.Enabled = true;
        }
    }
}
