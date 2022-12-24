import React from 'react';
import { Bar } from 'react-chartjs-2';
import { useSelector } from 'react-redux';
import NavbarComponent from '../../components/NavbarComponent/NavbarComponent';
import './ExamResultPage.css'

const ExamResultPage = () => {
  const exam = useSelector(state => state.exam);

  const getBarData = () => {
    console.log(exam.result)
  }
  return (
    <>
    <NavbarComponent></NavbarComponent>
    <div className="exam-result-page">
      <Bar data={getBarData()}></Bar>
    </div>
    </>
  )
}

export default ExamResultPage