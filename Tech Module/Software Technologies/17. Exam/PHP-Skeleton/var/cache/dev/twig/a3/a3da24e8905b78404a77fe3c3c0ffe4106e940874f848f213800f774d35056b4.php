<?php

/* base.html.twig */
class __TwigTemplate_93e2499d03c6402ea1e3906495568257ed0120721f7f5badb0e11600e82927c5 extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        $this->parent = false;

        $this->blocks = array(
            'title' => array($this, 'block_title'),
            'stylesheets' => array($this, 'block_stylesheets'),
            'body_id' => array($this, 'block_body_id'),
            'body' => array($this, 'block_body'),
            'main' => array($this, 'block_main'),
        );
    }

    protected function doDisplay(array $context, array $blocks = array())
    {
        $__internal_5e0264f65faf2c4842f01372832f9acfdb948ea2b88c13098ad2981d90e75efc = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_5e0264f65faf2c4842f01372832f9acfdb948ea2b88c13098ad2981d90e75efc->enter($__internal_5e0264f65faf2c4842f01372832f9acfdb948ea2b88c13098ad2981d90e75efc_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "base.html.twig"));

        $__internal_b49d0f4879ac4c1913ba107e38557482f747e1ba3f9809db65f89fc0d48be5d3 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_b49d0f4879ac4c1913ba107e38557482f747e1ba3f9809db65f89fc0d48be5d3->enter($__internal_b49d0f4879ac4c1913ba107e38557482f747e1ba3f9809db65f89fc0d48be5d3_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "base.html.twig"));

        // line 6
        echo "<!DOCTYPE html>
<html lang=\"en-US\">
<head>
    <meta charset=\"UTF-8\"/>
    <title>";
        // line 10
        $this->displayBlock('title', $context, $blocks);
        echo "</title>
    ";
        // line 11
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
        // line 20
        $this->displayBlock('body', $context, $blocks);
        // line 23
        echo "</body>
</html>
";
        
        $__internal_5e0264f65faf2c4842f01372832f9acfdb948ea2b88c13098ad2981d90e75efc->leave($__internal_5e0264f65faf2c4842f01372832f9acfdb948ea2b88c13098ad2981d90e75efc_prof);

        
        $__internal_b49d0f4879ac4c1913ba107e38557482f747e1ba3f9809db65f89fc0d48be5d3->leave($__internal_b49d0f4879ac4c1913ba107e38557482f747e1ba3f9809db65f89fc0d48be5d3_prof);

    }

    // line 10
    public function block_title($context, array $blocks = array())
    {
        $__internal_530a9f495cbea8149cb3f90f3f1ec5a650f4a5e18eed6dd38c5f5a1c92e0219a = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_530a9f495cbea8149cb3f90f3f1ec5a650f4a5e18eed6dd38c5f5a1c92e0219a->enter($__internal_530a9f495cbea8149cb3f90f3f1ec5a650f4a5e18eed6dd38c5f5a1c92e0219a_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "title"));

        $__internal_114bedf60379250afecadcff149164e589b690631f5ff3cb53542b390e0ffc7b = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_114bedf60379250afecadcff149164e589b690631f5ff3cb53542b390e0ffc7b->enter($__internal_114bedf60379250afecadcff149164e589b690631f5ff3cb53542b390e0ffc7b_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "title"));

        echo "Project Rider";
        
        $__internal_114bedf60379250afecadcff149164e589b690631f5ff3cb53542b390e0ffc7b->leave($__internal_114bedf60379250afecadcff149164e589b690631f5ff3cb53542b390e0ffc7b_prof);

        
        $__internal_530a9f495cbea8149cb3f90f3f1ec5a650f4a5e18eed6dd38c5f5a1c92e0219a->leave($__internal_530a9f495cbea8149cb3f90f3f1ec5a650f4a5e18eed6dd38c5f5a1c92e0219a_prof);

    }

    // line 11
    public function block_stylesheets($context, array $blocks = array())
    {
        $__internal_13d1210ba4eaedded826b98f838bdc1d86dc61d3d3178cec2da69729c3fe63e7 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_13d1210ba4eaedded826b98f838bdc1d86dc61d3d3178cec2da69729c3fe63e7->enter($__internal_13d1210ba4eaedded826b98f838bdc1d86dc61d3d3178cec2da69729c3fe63e7_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "stylesheets"));

        $__internal_7f64a241692bbcf0f174662013449e402aafa41fbe4047ee38398cf4f657645e = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_7f64a241692bbcf0f174662013449e402aafa41fbe4047ee38398cf4f657645e->enter($__internal_7f64a241692bbcf0f174662013449e402aafa41fbe4047ee38398cf4f657645e_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "stylesheets"));

        // line 12
        echo "        <link rel=\"stylesheet\" href=\"";
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("css/reset.css"), "html", null, true);
        echo "\">
        <link rel=\"stylesheet\" href=\"";
        // line 13
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("css/style.css"), "html", null, true);
        echo "\">
        <link rel=\"stylesheet\" href=\"";
        // line 14
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("css/create-style.css"), "html", null, true);
        echo "\">
    ";
        
        $__internal_7f64a241692bbcf0f174662013449e402aafa41fbe4047ee38398cf4f657645e->leave($__internal_7f64a241692bbcf0f174662013449e402aafa41fbe4047ee38398cf4f657645e_prof);

        
        $__internal_13d1210ba4eaedded826b98f838bdc1d86dc61d3d3178cec2da69729c3fe63e7->leave($__internal_13d1210ba4eaedded826b98f838bdc1d86dc61d3d3178cec2da69729c3fe63e7_prof);

    }

    // line 19
    public function block_body_id($context, array $blocks = array())
    {
        $__internal_d887e4afdf896e3967179e53fc5c8dd0012d3620c64555fa2737c9608009cb5c = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_d887e4afdf896e3967179e53fc5c8dd0012d3620c64555fa2737c9608009cb5c->enter($__internal_d887e4afdf896e3967179e53fc5c8dd0012d3620c64555fa2737c9608009cb5c_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "body_id"));

        $__internal_3d2235103491b781a4db12a6d5aa03fb1640648c8b55b83bed62bbb4edaed670 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_3d2235103491b781a4db12a6d5aa03fb1640648c8b55b83bed62bbb4edaed670->enter($__internal_3d2235103491b781a4db12a6d5aa03fb1640648c8b55b83bed62bbb4edaed670_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "body_id"));

        
        $__internal_3d2235103491b781a4db12a6d5aa03fb1640648c8b55b83bed62bbb4edaed670->leave($__internal_3d2235103491b781a4db12a6d5aa03fb1640648c8b55b83bed62bbb4edaed670_prof);

        
        $__internal_d887e4afdf896e3967179e53fc5c8dd0012d3620c64555fa2737c9608009cb5c->leave($__internal_d887e4afdf896e3967179e53fc5c8dd0012d3620c64555fa2737c9608009cb5c_prof);

    }

    // line 20
    public function block_body($context, array $blocks = array())
    {
        $__internal_4aa802a89d8aaaed9d6d590b2b2021e2a4b1f7be168f26ee1fe357fef842aed7 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_4aa802a89d8aaaed9d6d590b2b2021e2a4b1f7be168f26ee1fe357fef842aed7->enter($__internal_4aa802a89d8aaaed9d6d590b2b2021e2a4b1f7be168f26ee1fe357fef842aed7_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "body"));

        $__internal_052337be87f964a1cbb2868678a9afe057a0c282f2190b72b5f44ffb35e9fafd = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_052337be87f964a1cbb2868678a9afe057a0c282f2190b72b5f44ffb35e9fafd->enter($__internal_052337be87f964a1cbb2868678a9afe057a0c282f2190b72b5f44ffb35e9fafd_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "body"));

        // line 21
        echo "    ";
        $this->displayBlock('main', $context, $blocks);
        
        $__internal_052337be87f964a1cbb2868678a9afe057a0c282f2190b72b5f44ffb35e9fafd->leave($__internal_052337be87f964a1cbb2868678a9afe057a0c282f2190b72b5f44ffb35e9fafd_prof);

        
        $__internal_4aa802a89d8aaaed9d6d590b2b2021e2a4b1f7be168f26ee1fe357fef842aed7->leave($__internal_4aa802a89d8aaaed9d6d590b2b2021e2a4b1f7be168f26ee1fe357fef842aed7_prof);

    }

    public function block_main($context, array $blocks = array())
    {
        $__internal_ad55a4619fbc3679c908abf73922d746fcc2441c4da856ca34d3bdff19dbf03f = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_ad55a4619fbc3679c908abf73922d746fcc2441c4da856ca34d3bdff19dbf03f->enter($__internal_ad55a4619fbc3679c908abf73922d746fcc2441c4da856ca34d3bdff19dbf03f_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        $__internal_9741511045983b0d0eb6d5004c77320117d79e37d22ec941badf0581a9d7aeb3 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_9741511045983b0d0eb6d5004c77320117d79e37d22ec941badf0581a9d7aeb3->enter($__internal_9741511045983b0d0eb6d5004c77320117d79e37d22ec941badf0581a9d7aeb3_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        
        $__internal_9741511045983b0d0eb6d5004c77320117d79e37d22ec941badf0581a9d7aeb3->leave($__internal_9741511045983b0d0eb6d5004c77320117d79e37d22ec941badf0581a9d7aeb3_prof);

        
        $__internal_ad55a4619fbc3679c908abf73922d746fcc2441c4da856ca34d3bdff19dbf03f->leave($__internal_ad55a4619fbc3679c908abf73922d746fcc2441c4da856ca34d3bdff19dbf03f_prof);

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
        return array (  141 => 21,  132 => 20,  115 => 19,  103 => 14,  99 => 13,  94 => 12,  85 => 11,  67 => 10,  55 => 23,  53 => 20,  49 => 19,  42 => 16,  40 => 11,  36 => 10,  30 => 6,);
    }

    /** @deprecated since 1.27 (to be removed in 2.0). Use getSourceContext() instead */
    public function getSource()
    {
        @trigger_error('The '.__METHOD__.' method is deprecated since version 1.27 and will be removed in 2.0. Use getSourceContext() instead.', E_USER_DEPRECATED);

        return $this->getSourceContext()->getCode();
    }

    public function getSourceContext()
    {
        return new Twig_Source("{#
   This is the base template used as the application layout which contains the
   common elements and decorates all the other templates.
   See http://symfony.com/doc/current/book/templating.html#template-inheritance-and-layouts
#}
<!DOCTYPE html>
<html lang=\"en-US\">
<head>
    <meta charset=\"UTF-8\"/>
    <title>{% block title %}Project Rider{% endblock %}</title>
    {% block stylesheets %}
        <link rel=\"stylesheet\" href=\"{{ asset('css/reset.css') }}\">
        <link rel=\"stylesheet\" href=\"{{ asset('css/style.css') }}\">
        <link rel=\"stylesheet\" href=\"{{ asset('css/create-style.css') }}\">
    {% endblock %}
    <link rel=\"icon\" type=\"image/x-icon\" href=\"{{ asset('favicon.ico') }}\"/>
</head>

<body id=\"{% block body_id %}{% endblock %}\">
{% block body %}
    {% block main %}{% endblock %}
{% endblock %}
</body>
</html>
", "base.html.twig", "C:\\Users\\doba7a\\Desktop\\ex\\PHP-Skeleton\\app\\Resources\\views\\base.html.twig");
    }
}
