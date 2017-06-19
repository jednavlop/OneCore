// Validación del lado del cliente.
$(function () {
    $('#acceso-concedido').hide().removeClass('hidden');
    $('#acceso-denegado').hide().removeClass('hidden');
    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            if (regexp.constructor != RegExp)
                regexp = new RegExp(regexp);
            else if (regexp.global)
                regexp.lastIndex = 0;
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );
    $("form[name='acceso']").validate({
        debug: true,
        onkeyup: false,
        errorElementClass: 'control-error',
        errorClass: 'campo-error',
        errorElement: 'span',
        rules: {
            usuario: {
                required: true,
                minlength: 5
            },
            contraseña: {
                required: true,
                minlength: 5,
                regex: /^((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%_!&-]).{6,20})+/
            }
        },
        messages: {
            usuario: {
                required: 'Por favor escriba el nombre de usuario',
                minlength: 'El nombre debe tener mínimo 5 caracteres'
            },
            contraseña: {
                required: 'Por favor escriba la contraseña de acceso',
                minlength: 'La contraseña de acceso debe tener mínimo 5 caracteres',
                regex: 'La contraseña de acceso debe contener almenos una letra mayúscula, un número y un símbolo.'
            }
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass(this.settings.errorElementClass).removeClass(errorClass);
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass(this.settings.errorElementClass).removeClass(errorClass);
        },
        errorPlacement: function (error, element) {
            error.insertAfter(element[0].parentNode);
        },
        submitHandler: function (form) {
            $.ajax({
                url: '/Acceso/Entrar',
                type: 'POST',
                data: $('#formulario-acceso').serialize(),
                success: function (respuesta) {
                    if (respuesta == true)
                    {
                        $('#acceso-denegado').slideUp(400, function () { $('#acceso-concedido').slideDown(400, function () { window.location = 'Inicio'; }); });
                    }
                    else
                    {
                        $('#acceso-concedido').slideUp(400, function () { $('#acceso-denegado').slideDown(); });
                    }
                },
                error: function (respuesta) {
                    $('#acceso-concedido').slideUp(400, function () { $('#acceso-denegado').slideDown(); });
                }
            });
        }
    });
});