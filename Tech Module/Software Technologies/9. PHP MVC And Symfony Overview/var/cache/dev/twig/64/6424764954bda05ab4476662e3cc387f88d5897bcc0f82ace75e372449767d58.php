<?php

/* base.html.twig */
class __TwigTemplate_ddcd439a3f2eb218b369e5d1cb4cc30a7c19bb286f4d94c2cf52676d3b67893d extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        $this->parent = false;

        $this->blocks = array(
            'title' => array($this, 'block_title'),
            'stylesheets' => array($this, 'block_stylesheets'),
            'body_id' => array($this, 'block_body_id'),
            'header' => array($this, 'block_header'),
            'body' => array($this, 'block_body'),
            'main' => array($this, 'block_main'),
            'javascripts' => array($this, 'block_javascripts'),
        );
    }

    protected function doDisplay(array $context, array $blocks = array())
    {
        $__internal_f621212f9f07c9ac5db41ec2a0ea8c0f521a13cc1650509e72cc9fc877a78d1c = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_f621212f9f07c9ac5db41ec2a0ea8c0f521a13cc1650509e72cc9fc877a78d1c->enter($__internal_f621212f9f07c9ac5db41ec2a0ea8c0f521a13cc1650509e72cc9fc877a78d1c_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "base.html.twig"));

        // line 6
        echo "<!DOCTYPE html>
<html lang=\"en-US\">
<head>
    <meta charset=\"UTF-8\"/>
    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"/>
    <title>";
        // line 11
        $this->displayBlock('title', $context, $blocks);
        echo "</title>
    ";
        // line 12
        $this->displayBlock('stylesheets', $context, $blocks);
        // line 16
        echo "    <link rel=\"icon\" type=\"image/x-icon\" href=\"";
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("favicon.ico"), "html", null, true);
        echo "\"/>
</head>

<body id=\"";
        // line 19
        $this->displayBlock('body_id', $context, $blocks);
        echo "\">

";
        // line 21
        $this->displayBlock('header', $context, $blocks);
        // line 39
        echo "
<div class=\"container body-container\">
    ";
        // line 41
        $this->displayBlock('body', $context, $blocks);
        // line 48
        echo "</div>


";
        // line 51
        $this->displayBlock('javascripts', $context, $blocks);
        // line 57
        echo "
</body>
</html>
";
        
        $__internal_f621212f9f07c9ac5db41ec2a0ea8c0f521a13cc1650509e72cc9fc877a78d1c->leave($__internal_f621212f9f07c9ac5db41ec2a0ea8c0f521a13cc1650509e72cc9fc877a78d1c_prof);

    }

    // line 11
    public function block_title($context, array $blocks = array())
    {
        $__internal_5075be330e2afbcf7ece67ded0b4eaf6be371ecf84653fea89f9ad6f9bf8ade4 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_5075be330e2afbcf7ece67ded0b4eaf6be371ecf84653fea89f9ad6f9bf8ade4->enter($__internal_5075be330e2afbcf7ece67ded0b4eaf6be371ecf84653fea89f9ad6f9bf8ade4_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "title"));

        echo "Calculator";
        
        $__internal_5075be330e2afbcf7ece67ded0b4eaf6be371ecf84653fea89f9ad6f9bf8ade4->leave($__internal_5075be330e2afbcf7ece67ded0b4eaf6be371ecf84653fea89f9ad6f9bf8ade4_prof);

    }

    // line 12
    public function block_stylesheets($context, array $blocks = array())
    {
        $__internal_f88264c045636a0b00d71acec1f1e202aa2dd8191e7eb719a970bbde606e8493 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_f88264c045636a0b00d71acec1f1e202aa2dd8191e7eb719a970bbde606e8493->enter($__internal_f88264c045636a0b00d71acec1f1e202aa2dd8191e7eb719a970bbde606e8493_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "stylesheets"));

        // line 13
        echo "        <link rel=\"stylesheet\" href=\"";
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("css/style.css"), "html", null, true);
        echo "\">
        <link rel=\"stylesheet\" href=\"";
        // line 14
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("css/bootstrap-datetimepicker.min.css"), "html", null, true);
        echo "\">
    ";
        
        $__internal_f88264c045636a0b00d71acec1f1e202aa2dd8191e7eb719a970bbde606e8493->leave($__internal_f88264c045636a0b00d71acec1f1e202aa2dd8191e7eb719a970bbde606e8493_prof);

    }

    // line 19
    public function block_body_id($context, array $blocks = array())
    {
        $__internal_a0ab05ae3cfdf33bac15abc93b68f9839768d02c31e0bab687bf490677c16cdc = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_a0ab05ae3cfdf33bac15abc93b68f9839768d02c31e0bab687bf490677c16cdc->enter($__internal_a0ab05ae3cfdf33bac15abc93b68f9839768d02c31e0bab687bf490677c16cdc_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "body_id"));

        
        $__internal_a0ab05ae3cfdf33bac15abc93b68f9839768d02c31e0bab687bf490677c16cdc->leave($__internal_a0ab05ae3cfdf33bac15abc93b68f9839768d02c31e0bab687bf490677c16cdc_prof);

    }

    // line 21
    public function block_header($context, array $blocks = array())
    {
        $__internal_1c5456835e374849a0b12a0ca80bd3904e9a6cfb16325e42ec11f108e1d37bac = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_1c5456835e374849a0b12a0ca80bd3904e9a6cfb16325e42ec11f108e1d37bac->enter($__internal_1c5456835e374849a0b12a0ca80bd3904e9a6cfb16325e42ec11f108e1d37bac_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "header"));

        // line 22
        echo "    <header>
        <div class=\"navbar navbar-default navbar-static-top\" role=\"navigation\">
            <div class=\"container\">
                <div class=\"navbar-header\">
                    <a href=\"";
        // line 26
        echo $this->env->getExtension('Symfony\Bridge\Twig\Extension\RoutingExtension')->getPath("index");
        echo "\" class=\"navbar-brand\">CALCULATOR</a>

                    <button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\".navbar-collapse\">
                        <span class=\"icon-bar\"></span>
                        <span class=\"icon-bar\"></span>
                        <span class=\"icon-bar\"></span>
                    </button>
                </div>

            </div>
        </div>
    </header>
";
        
        $__internal_1c5456835e374849a0b12a0ca80bd3904e9a6cfb16325e42ec11f108e1d37bac->leave($__internal_1c5456835e374849a0b12a0ca80bd3904e9a6cfb16325e42ec11f108e1d37bac_prof);

    }

    // line 41
    public function block_body($context, array $blocks = array())
    {
        $__internal_6ee5cb09002592b425515cc9a4cd5db0ba2c23d1fd2bd256cfc6a568584394ed = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_6ee5cb09002592b425515cc9a4cd5db0ba2c23d1fd2bd256cfc6a568584394ed->enter($__internal_6ee5cb09002592b425515cc9a4cd5db0ba2c23d1fd2bd256cfc6a568584394ed_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "body"));

        // line 42
        echo "        <div class=\"row\">
            <div id=\"main\" class=\"col-sm-9\">
                ";
        // line 44
        $this->displayBlock('main', $context, $blocks);
        // line 45
        echo "            </div>
        </div>
    ";
        
        $__internal_6ee5cb09002592b425515cc9a4cd5db0ba2c23d1fd2bd256cfc6a568584394ed->leave($__internal_6ee5cb09002592b425515cc9a4cd5db0ba2c23d1fd2bd256cfc6a568584394ed_prof);

    }

    // line 44
    public function block_main($context, array $blocks = array())
    {
        $__internal_8ee78bec52d2ccdbb3e5d94bddf69091633051f87bd646852a17e3a45f37e8c6 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_8ee78bec52d2ccdbb3e5d94bddf69091633051f87bd646852a17e3a45f37e8c6->enter($__internal_8ee78bec52d2ccdbb3e5d94bddf69091633051f87bd646852a17e3a45f37e8c6_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        
        $__internal_8ee78bec52d2ccdbb3e5d94bddf69091633051f87bd646852a17e3a45f37e8c6->leave($__internal_8ee78bec52d2ccdbb3e5d94bddf69091633051f87bd646852a17e3a45f37e8c6_prof);

    }

    // line 51
    public function block_javascripts($context, array $blocks = array())
    {
        $__internal_ec55b9dca615184c05a49fb5bb29f2a095982259ca508f4bd3728be84b121e8e = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_ec55b9dca615184c05a49fb5bb29f2a095982259ca508f4bd3728be84b121e8e->enter($__internal_ec55b9dca615184c05a49fb5bb29f2a095982259ca508f4bd3728be84b121e8e_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "javascripts"));

        // line 52
        echo "    <script src=\"";
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("js/jquery-2.2.4.min.js"), "html", null, true);
        echo "\"></script>
    <script src=\"";
        // line 53
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("js/moment.min.js"), "html", null, true);
        echo "\"></script>
    <script src=\"";
        // line 54
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("js/bootstrap.js"), "html", null, true);
        echo "\"></script>
    <script src=\"";
        // line 55
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("js/bootstrap-datetimepicker.min.js"), "html", null, true);
        echo "\"></script>
";
        
        $__internal_ec55b9dca615184c05a49fb5bb29f2a095982259ca508f4bd3728be84b121e8e->leave($__internal_ec55b9dca615184c05a49fb5bb29f2a095982259ca508f4bd3728be84b121e8e_prof);

    }

    public function getTemplateName()
    {
        return "base.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  205 => 55,  201 => 54,  197 => 53,  192 => 52,  186 => 51,  175 => 44,  166 => 45,  164 => 44,  160 => 42,  154 => 41,  134 => 26,  128 => 22,  122 => 21,  111 => 19,  102 => 14,  97 => 13,  91 => 12,  79 => 11,  69 => 57,  67 => 51,  62 => 48,  60 => 41,  56 => 39,  54 => 21,  49 => 19,  42 => 16,  40 => 12,  36 => 11,  29 => 6,);
    }

    public function getSource()
    {
        return "{#
   This is the base template used as the application layout which contains the
   common elements and decorates all the other templates.
   See http://symfony.com/doc/current/book/templating.html#template-inheritance-and-layouts
#}
<!DOCTYPE html>
<html lang=\"en-US\">
<head>
    <meta charset=\"UTF-8\"/>
    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"/>
    <title>{% block title %}Calculator{% endblock %}</title>
    {% block stylesheets %}
        <link rel=\"stylesheet\" href=\"{{ asset('css/style.css') }}\">
        <link rel=\"stylesheet\" href=\"{{ asset('css/bootstrap-datetimepicker.min.css') }}\">
    {% endblock %}
    <link rel=\"icon\" type=\"image/x-icon\" href=\"{{ asset('favicon.ico') }}\"/>
</head>

<body id=\"{% block body_id %}{% endblock %}\">

{% block header %}
    <header>
        <div class=\"navbar navbar-default navbar-static-top\" role=\"navigation\">
            <div class=\"container\">
                <div class=\"navbar-header\">
                    <a href=\"{{ path('index') }}\" class=\"navbar-brand\">CALCULATOR</a>

                    <button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\".navbar-collapse\">
                        <span class=\"icon-bar\"></span>
                        <span class=\"icon-bar\"></span>
                        <span class=\"icon-bar\"></span>
                    </button>
                </div>

            </div>
        </div>
    </header>
{% endblock %}

<div class=\"container body-container\">
    {% block body %}
        <div class=\"row\">
            <div id=\"main\" class=\"col-sm-9\">
                {% block main %}{% endblock %}
            </div>
        </div>
    {% endblock %}
</div>


{% block javascripts %}
    <script src=\"{{ asset('js/jquery-2.2.4.min.js') }}\"></script>
    <script src=\"{{ asset('js/moment.min.js') }}\"></script>
    <script src=\"{{ asset('js/bootstrap.js') }}\"></script>
    <script src=\"{{ asset('js/bootstrap-datetimepicker.min.js') }}\"></script>
{% endblock %}

</body>
</html>
";
    }
}
