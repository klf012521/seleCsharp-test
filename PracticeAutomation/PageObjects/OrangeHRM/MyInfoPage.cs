﻿using CynkyDriver;
using OpenQA.Selenium;
using PracticeAutomation.Models.UI;
using PracticeAutomation.PageObjects.CommonPages;

namespace PracticeAutomation.PageObjects.OrangeHRM
{
    public class MyInfoPage : Navigation
    {
        public MyInfoPage(IWebDriver driver) : base(driver) { }

        #region Locators

        PageElement InputField_textbox(string name) => new PageElement(_Driver, By.XPath($"//input[@name='{name}']"));

        #endregion

        #region Actions

        public void UpdateInfo(PersonalDetails personalDetails)
        {
            InputField_textbox("firstName").SendKeys(personalDetails.Firstname);
            ClickButton("Save");
        }

        public string GetTextFromInputField(string fieldName)
        {
            return InputField_textbox(fieldName).GetAttribute("value");
        }

        #endregion
    }
}