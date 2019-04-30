using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        private SortedList<string, string> taskList = new SortedList<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
           try
            {
                if (txtTask.Text != string.Empty)
                {
                    if(!IsDateAlreadyChosen())
                    {
                        taskList.Add(dtpTaskDate.Value.ToString("d"), txtTask.Text);
                        lstTasks.Items.Add(dtpTaskDate.Value.ToString("d"));

                        txtTask.Clear();
                    }

                    else
                    {
                        txtTask.Focus();
                    }
                    
                }
                else
                {
                    MessageBox.Show("You must enter a task.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsDateAlreadyChosen()
        {
            foreach(object date in lstTasks.Items)
            {
                if(dtpTaskDate.Value.ToString("d") == date.ToString())
                {
                    MessageBox.Show("Only one task per day is allowed");
                    return true;
                }
            }

            return false;
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstTasks.SelectedItem != null)
            {
                lblTaskDetails.Text = taskList[lstTasks.SelectedItem.ToString()];
            }
            
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {           
            try
            {
                if (lstTasks.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select the task to be deleted");
                }

                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this task?", "Confirmation", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation);

                    //I am removing the item from the sorted list and in the listbox
                    if (result == DialogResult.Yes)
                    {
                        //gotta make sure that this is in the correct order XD
                        taskList.Remove(lstTasks.SelectedItem.ToString());
                        lstTasks.Items.Remove(lstTasks.SelectedItem);
                        txtTask.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {

        }
    }
}
