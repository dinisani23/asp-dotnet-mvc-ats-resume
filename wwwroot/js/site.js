document.addEventListener('DOMContentLoaded', function() {
    //1 skills tag      
    const tags = document.getElementById('tags');
    const input = document.getElementById('input-tag');

    if (input && tags) {
        input.addEventListener('keydown', function (event) {
            if (event.key === 'Enter') {
                event.preventDefault();
                const tag = document.createElement('li');
                const tagContent = input.value.trim();
                if (tagContent !== '') {
                    tag.innerText = tagContent;
                    tag.innerHTML += '<button class="delete-button">X</button>';
                    tags.appendChild(tag);
                    input.value = '';
                }
            }
        });

        tags.addEventListener('click', function (event) {
            if (event.target.classList.contains('delete-button')) {
                event.target.parentNode.remove();
            }
        });

        
    }
    
    /*function prepareTags() {
            const tagElements = tags.getElementsByTagName('li');
            const tagValues = [];
            for (let i = 0; i < tagElements.length; i++) {
                tagValues.push(tagElements[i].innerText);
            }
            document.getElementById('hidden-tags').value = tagValues.join(',');
        }*/

    function addProject() {
        let projectCount = 1;
        const addProjectButton = document.getElementById('addProjectButton');
        if (addProjectButton) {
            addProjectButton.addEventListener('click', function() {
                projectCount++;
                
                let projectExperience = document.getElementById('projectExperience');
                if (projectExperience) {
                    let cloneProj = projectExperience.cloneNode(true);
                    
                    let deleteProjButton = document.createElement('button');
                    deleteProjButton.type = 'button';
                    deleteProjButton.className = 'btn btn-outline-danger';
                    deleteProjButton.innerHTML = '<i class="bi bi-trash3"></i>';
                    
                    deleteProjButton.addEventListener('click', function() {
                        cloneProj.remove();
                    });
                    
                    cloneProj.querySelector('.px-5').appendChild(deleteProjButton);
                    
                    const projNode = document.getElementById("projectContainer");
                    if (projNode) {
                        projNode.appendChild(cloneProj);
                    }
                }
            });
        }
    }
    addProject();

    function addCert() {
        let certificationCount = 1;
        const addCertificationButton = document.getElementById('addCertificationButton');
        if (addCertificationButton) {
            addCertificationButton.addEventListener('click', function() {
                certificationCount++;
                
                let certificationExperience = document.getElementById('certificationExperience');
                if (certificationExperience) {
                    let cloneCert = certificationExperience.cloneNode(true);
                    
                    let deleteCertButton = document.createElement('button');
                    deleteCertButton.type = 'button';
                    deleteCertButton.className = 'btn btn-outline-danger';
                    deleteCertButton.innerHTML = '<i class="bi bi-trash3"></i>';
                    
                    deleteCertButton.addEventListener('click', function() {
                        cloneCert.remove();
                    });
                    
                    cloneCert.querySelector('.px-5').appendChild(deleteCertButton);
                    
                    const certNode = document.getElementById("certificationContainer");
                    if (certNode) {
                        certNode.appendChild(cloneCert);
                    }
                }
            });
        }
    }
    addCert();

    function addEducation() {
        let educationCount = 1;
        const addEducationButton = document.getElementById('addEducationButton');
        if (addEducationButton) {
            addEducationButton.addEventListener('click', function() {
                educationCount++;
                
                let educationExperience = document.getElementById('educationExperience');
                if (educationExperience) {
                    let cloneEdu = educationExperience.cloneNode(true);
                    
                    let deleteEduButton = document.createElement('button');
                    deleteEduButton.type = 'button';
                    deleteEduButton.className = 'btn btn-outline-danger';
                    deleteEduButton.innerHTML = '<i class="bi bi-trash3"></i>';
                    
                    deleteEduButton.addEventListener('click', function() {
                        cloneEdu.remove();
                    });
                    
                    cloneEdu.querySelector('.px-5').appendChild(deleteEduButton);
                    
                    const eduNode = document.getElementById("educationContainer");
                    if (eduNode) {
                        eduNode.appendChild(cloneEdu);
                    }
                }
            });
        }
    }
    addEducation();

    function addExperience() {
        let experienceCount = 1;
        const addExperienceButton = document.getElementById('addExperienceButton');
        if (addExperienceButton) {
            addExperienceButton.addEventListener('click', function() {
                experienceCount++;
                
                let workExperience = document.getElementById('workExperience');
                if (workExperience) {
                    let clone = workExperience.cloneNode(true);
                    
                    let deleteButton = document.createElement('button');
                    deleteButton.type = 'button';
                    deleteButton.className = 'btn btn-outline-danger';
                    deleteButton.innerHTML = '<i class="bi bi-trash3"></i>';
                    
                    deleteButton.addEventListener('click', function() {
                        clone.remove();
                    });
                    
                    clone.querySelector('.px-5').appendChild(deleteButton);
                    
                    const node = document.getElementById("experienceContainer");
                    if (node) {
                        node.appendChild(clone);
                    }
                }
            });
        }
    }
    addExperience();
});
