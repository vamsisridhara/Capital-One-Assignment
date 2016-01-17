using System;
using TechTalk.SpecFlow;

namespace SpecFlowDemo
{
    [Binding]
    public class BrushingofTeethSteps
    {
        [Given(@"the mouth is open")]
        public void GivenTheMouthIsOpen()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the back teeth are brushed")]
        public void WhenTheBackTeethAreBrushed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"x")]
        public void WhenX()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the teeth look clean")]
        public void ThenTheTeethLookClean()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the mouth feels fresh")]
        public void ThenTheMouthFeelsFresh()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the braces arent damaged")]
        public void ThenTheBracesArentDamaged()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"z")]
        public void ThenZ()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
