﻿using Bifrost.Rules;
using Bifrost.Validation.Rules;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Bifrost.Specs.Validation.Rules.for_LessThanOrEqual
{
    public class when_checking_value_that_is_less_than
    {
        static bool result;
        static LessThanOrEqual<double> rule;
        static Mock<IRuleContext> rule_context_mock;

        Establish context = () => 
        {
            rule = new LessThanOrEqual<double>(42.0);
            rule_context_mock = new Mock<IRuleContext>();
        };

        Because of = () => result = rule.IsSatisfiedBy(rule_context_mock.Object, 41.0);

        It should_be_valid = () => result.ShouldBeTrue();
    }
}
