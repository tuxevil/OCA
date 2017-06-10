// jQuery version of required-if validation, if that framework is loaded
if (typeof (jQuery) !== "undefined" && typeof (jQuery.validator) !== "undefined") {

    (function($) {

        $.validator.addMethod('requiredif', function(value, element, parameters) {
            var id = '#' + parameters['dependentProperty'];

            // get the target value (as a string, as that's what actual value will be)
            var targetvalue = parameters['targetValue'];
            targetvalue = (targetvalue == null ? '' : targetvalue).toString();

            // get the actual value of the target control
            var actualvalue = $(id).val();

            // if the condition is true, reuse the existing required field validator functionality
            if (targetvalue === actualvalue)
                return $.validator.methods.required.call(this, value, element, parameters);

            return true;
        });

        $.validator.addMethod("notequalto", function(value, element, parameters) {
            var id = '#' + parameters['otherProperty'];
            var otherPropertyValue = $(id).val();

            if (otherPropertyValue != "" || value != "")
                return otherPropertyValue != value;
            return true;
        });

        $.validator.addMethod("equalto", function(value, element, parameters) {
            var id = '#' + parameters['otherProperty'];
            var otherPropertyValue = $(id).val();

            if (otherPropertyValue != "" || value != "")
                return otherPropertyValue == value;
            return true;
        });

        $.validator.addMethod("requiredwith", function(value, element, parameters) {
            var id = '#' + parameters['otherProperty'];
            var otherPropertyValue = $(id).val();

            return !((otherPropertyValue != "" && value == "") || (value != "" && otherPropertyValue == ""));
        });

        $.validator.addMethod("requiredoneof", function(value, element, parameters) {
            var id = '#' + parameters['otherProperty'];
            var otherPropertyValue = $(id).val();

            return (otherPropertyValue != "" || value != "")
        });

        $.validator.addMethod("remoteWithConfirm", function(value, element, param) {
            if (this.optional(element))
                return "dependency-mismatch";

            var previous = this.previousValue(element);
            if (!this.settings.messages[element.name])
                this.settings.messages[element.name] = {};
            previous.originalMessage = this.settings.messages[element.name].remote;
            this.settings.messages[element.name].remote = previous.message;

            param = typeof param == "string" && { url: param} || param;

            if (previous.old !== value) {
                previous.old = value;
                var validator = this;
                this.startRequest(element);
                var data = {};
                data[element.name] = value;
                $.ajax($.extend(true, {
                    url: param,
                    mode: "abort",
                    port: "validate" + element.name,
                    dataType: "json",
                    data: data,
                    success: function(response) {
                        validator.settings.messages[element.name].remote = previous.originalMessage;
                        var valid = response === true;
                        if (valid) {
                            var submitted = validator.formSubmitted;
                            validator.prepareElement(element);
                            validator.formSubmitted = submitted;
                            validator.successList.push(element);
                            validator.showErrors();
                        } else {
                            var errors = {};
                            var message = (previous.message = response || validator.defaultMessage(element, "remoteWithConfirm"));
                            errors[element.name] = $.isFunction(message) ? message(value) : message;
                            validator.showErrors(errors);
                        }

                        if (param["successFunction"])
                            eval(param["successFunction"] + "(response);");

                        previous.valid = valid;
                        validator.stopRequest(element, valid);
                    }
                }, param));
                return "pending";
            } else if (this.pending[element.name]) {
                return "pending";
            }
            return previous.valid;
        });

    })(jQuery);
}