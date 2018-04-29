﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToFast.Data;
using ToFast.Forms;

namespace ToFast
{
    /// <summary>
    /// 작성자   : 정재원
    /// 작성일   : 18-04-24 15:49
    /// 수정내용 : 로고 변경?
    /// </summary>
    /// <summary>
    /// 작성자: 소재홍
    /// 작성일: 18.04.24 16:34
    /// 수정: 
    /// </summary>
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbbType.Text == "")
            {
                MessageBox.Show(@"구분을 선택해주세요.");
                return;
            }
            else if (cbbType.Text == @"교수님용")
            {
                Teacher teacher = DataRepository.Teacher.GetByIdAndPassword(tbName.Text, tbPassword.Text);

                if (teacher == null)
                {
                    MessageBox.Show(@"아이디 또는 비밀번호가 다릅니다. 확인해주세요.");
                }
                else
                {
                    RootFromShow(new TrayProfIcon());
                }
            }
            else if (cbbType.Text == @"학생용")
            {
                Data.Student student = DataRepository.Student.GetByIdAndPassword(tbName.Text, tbPassword.Text);

                if (student == null)
                {
                    MessageBox.Show(@"아이디 또는 비밀번호가 다릅니다. 확인해주세요.");
                    return;
                }
                if (student.LogIn == true)
                {
                    MessageBox.Show(@"이미 로그인 중인 아이디입니다.");
                    return;
                }

                student.LogIn = true;

                DataRepository.Student.Update(student);

                DataRepository.User = student;

                RootFromShow(new TrayStudentIcon());
            }
        }

        private void RootFromShow(Control form)
        {
            this.Visible = false;
            form.Show();
        }
    }
}