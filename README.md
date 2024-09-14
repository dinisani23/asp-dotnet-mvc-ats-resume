# Resume Generator Web Application

## Overview
The Resume Generator Web Application is a .NET Core MVC web app that allows users to create and download a professional resume in PDF format. Users input their personal information, work experience, educational background, certifications, and projects through a web form, and the application generates a formatted PDF resume.

## Features
- Form Submission: Users can input their personal details, skills, work experience, education, certifications, and projects.
- PDF Generation: The application creates a well-formatted resume in PDF format using the iTextSharp library.
- File Download: Users can download the generated PDF resume directly from the web application.

## Technologies Used
- ASP.NET Core MVC: Framework for building the web application.
- iTextSharp: Library for generating PDF documents.
- C#: Programming language used for application logic.
- HTML/CSS: Used for creating the web form and styling.

## Usage
- Fill Out the Form: Enter your details, including name, city, phone, email, skills, employment history, education, certifications, and projects into the provided form fields.
- Submit the Form: Click the submit button to generate your resume.
- Download the Resume: The application will generate a PDF and provide a link for you to download the file.

## Code Structure
- Controllers: Contains the CandidateController which handles form submissions and PDF generation.
- Models: Contains the Candidate model that represents the data structure for the resume.
- Views: Contains the Razor view files (e.g., Index.cshtml) for rendering the form.
