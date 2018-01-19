<?php

/* project/create.html.twig */
class __TwigTemplate_2a1b5d707aa72104692b6ffa1a05c4fb1e74d1bf350d67ef9d0e176233c33cfd extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        // line 1
        $this->parent = $this->loadTemplate("base.html.twig", "project/create.html.twig", 1);
        $this->blocks = array(
            'main' => array($this, 'block_main'),
        );
    }

    protected function doGetParent(array $context)
    {
        return "base.html.twig";
    }

    protected function doDisplay(array $context, array $blocks = array())
    {
        $__internal_57c3ce00237a80e3e0ec8c8f58dfb6f6c054e78e1c5ab58173fca6065961df47 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_57c3ce00237a80e3e0ec8c8f58dfb6f6c054e78e1c5ab58173fca6065961df47->enter($__internal_57c3ce00237a80e3e0ec8c8f58dfb6f6c054e78e1c5ab58173fca6065961df47_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "project/create.html.twig"));

        $__internal_8795cead5d9c71f5869a7821a54cafb4834b8538ed288efc532af6b4a910ab11 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_8795cead5d9c71f5869a7821a54cafb4834b8538ed288efc532af6b4a910ab11->enter($__internal_8795cead5d9c71f5869a7821a54cafb4834b8538ed288efc532af6b4a910ab11_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "project/create.html.twig"));

        $this->parent->display($context, array_merge($this->blocks, $blocks));
        
        $__internal_57c3ce00237a80e3e0ec8c8f58dfb6f6c054e78e1c5ab58173fca6065961df47->leave($__internal_57c3ce00237a80e3e0ec8c8f58dfb6f6c054e78e1c5ab58173fca6065961df47_prof);

        
        $__internal_8795cead5d9c71f5869a7821a54cafb4834b8538ed288efc532af6b4a910ab11->leave($__internal_8795cead5d9c71f5869a7821a54cafb4834b8538ed288efc532af6b4a910ab11_prof);

    }

    // line 3
    public function block_main($context, array $blocks = array())
    {
        $__internal_3098c6409d96eb2f3293d52e5daf3ed25b1298192f1135dd2d7abfe9eb91d62a = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_3098c6409d96eb2f3293d52e5daf3ed25b1298192f1135dd2d7abfe9eb91d62a->enter($__internal_3098c6409d96eb2f3293d52e5daf3ed25b1298192f1135dd2d7abfe9eb91d62a_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        $__internal_e0efd01e66176f381b6cabb388c10f2f77b3c29a372915341c5936683fd8c540 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_e0efd01e66176f381b6cabb388c10f2f77b3c29a372915341c5936683fd8c540->enter($__internal_e0efd01e66176f381b6cabb388c10f2f77b3c29a372915341c5936683fd8c540_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        // line 4
        echo "<div class=\"wrapper\">
    <form class=\"project-create\" method=\"post\">
        <div class=\"create-header\">
            Create Project
        </div>
        <div class=\"create-title\">
            <div class=\"create-title-label\">Title</div>
            <input class=\"create-title-content\" name=\"project[title]\" />
        </div>
        <div class=\"create-description\">
            <div class=\"create-description-label\">Description</div>
            <textarea rows=\"3\" class=\"create-description-content\" name=\"project[description]\"></textarea>
        </div>
        <div class=\"create-budget\">
            <div class=\"create-budget-label\">Budget</div>
            <input type=\"number\" min=\"0\" class=\"create-budget-content\" name=\"project[budget]\" />
        </div>
        <div class=\"create-button-holder\">
            <button type=\"submit\" class=\"submit-button\">Create Project</button>
            <a type=\"button\" href=\"/\" class=\"back-button\">Back</a>
        </div>

        ";
        // line 26
        echo $this->env->getRuntime('Symfony\Bridge\Twig\Form\TwigRenderer')->searchAndRenderBlock($this->getAttribute(($context["form"] ?? $this->getContext($context, "form")), "_token", array()), 'row');
        echo "
    </form>
</div>
";
        
        $__internal_e0efd01e66176f381b6cabb388c10f2f77b3c29a372915341c5936683fd8c540->leave($__internal_e0efd01e66176f381b6cabb388c10f2f77b3c29a372915341c5936683fd8c540_prof);

        
        $__internal_3098c6409d96eb2f3293d52e5daf3ed25b1298192f1135dd2d7abfe9eb91d62a->leave($__internal_3098c6409d96eb2f3293d52e5daf3ed25b1298192f1135dd2d7abfe9eb91d62a_prof);

    }

    public function getTemplateName()
    {
        return "project/create.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  73 => 26,  49 => 4,  40 => 3,  11 => 1,);
    }

    /** @deprecated since 1.27 (to be removed in 2.0). Use getSourceContext() instead */
    public function getSource()
    {
        @trigger_error('The '.__METHOD__.' method is deprecated since version 1.27 and will be removed in 2.0. Use getSourceContext() instead.', E_USER_DEPRECATED);

        return $this->getSourceContext()->getCode();
    }

    public function getSourceContext()
    {
        return new Twig_Source("{% extends \"base.html.twig\" %}

{% block main %}
<div class=\"wrapper\">
    <form class=\"project-create\" method=\"post\">
        <div class=\"create-header\">
            Create Project
        </div>
        <div class=\"create-title\">
            <div class=\"create-title-label\">Title</div>
            <input class=\"create-title-content\" name=\"project[title]\" />
        </div>
        <div class=\"create-description\">
            <div class=\"create-description-label\">Description</div>
            <textarea rows=\"3\" class=\"create-description-content\" name=\"project[description]\"></textarea>
        </div>
        <div class=\"create-budget\">
            <div class=\"create-budget-label\">Budget</div>
            <input type=\"number\" min=\"0\" class=\"create-budget-content\" name=\"project[budget]\" />
        </div>
        <div class=\"create-button-holder\">
            <button type=\"submit\" class=\"submit-button\">Create Project</button>
            <a type=\"button\" href=\"/\" class=\"back-button\">Back</a>
        </div>

        {{ form_row(form._token) }}
    </form>
</div>
{% endblock %}", "project/create.html.twig", "C:\\Users\\doba7a\\Desktop\\ex\\PHP-Skeleton\\app\\Resources\\views\\project\\create.html.twig");
    }
}
