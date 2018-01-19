const Project = require('../models/Project');

module.exports = {
    index: (req, res) => {
        Project.find().then(projects => {
                return res.render('project/index', {'projects': projects});
        });
    },
    createGet: (req, res) => {
        res.render('project/create');
    },
    createPost: (req, res) => {
        let project = req.body;

        Project.create(project).then(project => {
            res.redirect("/");
        })
    },
    editGet: (req, res) => {
        let projectId = req.params.id;

        Project.findById(projectId).then(project => {
            res.render('project/edit', project)
        })
    },
    editPost: (req, res) => {
        let projectId = req.params.id;
        let project = req.body;

        Project.findByIdAndUpdate(projectId, project, {runValidators: true}).then(project => {
            res.redirect("/");
        })
    },
    deleteGet: (req, res) => {
        let projectId = req.params.id;

        Project.findById(projectId).then(project => {
            res.render('project/delete', project)
        })
    },
    deletePost: (req, res) => {
        let projectId = req.params.id;

        Project.findByIdAndRemove(projectId).then(data => {
            res.redirect("/");
        })
    }
};