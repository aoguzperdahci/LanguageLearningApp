import React from 'react';
import { Bar, Pie } from 'react-chartjs-2';
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
  ArcElement
} from 'chart.js';

import { useSelector } from 'react-redux';
import NavbarComponent from '../../components/NavbarComponent/NavbarComponent';
import './ExamResultPage.css'
import { Col, Row } from 'react-bootstrap';

ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement,
  ArcElement,
  Title,
  Tooltip,
  Legend,
);

const ExamResultPage = () => {
  const exam = useSelector(state => state.exam);

  const optionsBar = {
    responsive: true,
    plugins: {
      legend: {
        position: 'top',
        labels: {
          font: {
            size: 16
          }
        }
      },
    },
    scales: {
      x: {
        ticks: {
          font: {
            size: 20
          }
        },
      },
      y: {
        min: 0,
        max: 4,
        ticks: {
          font: {
            size: 20
          },
          stepSize: 1
        },
      }
    }
  };

  const optionsPie = {
    responsive: true,
    plugins: {
      legend: {
        position: 'top',
        labels: {
          font: {
            size: 16
          }
        }
      },
    },
  };


  const getBarData = () => {
    let correctAnswers = [0,0,0];
    let wrongAnswers = [0,0,0];

    exam.result.forEach(element => {
      let list = element.correct ? correctAnswers : wrongAnswers;
      list[element.difficulty]++;
    });

    return {
      labels: ["Easy Questions", "Medium Questions", "Hard Questions"],
      datasets: [
        {
          label: "Correct Answer",
          data: correctAnswers,
          backgroundColor: "#00E676",
        },
        {
          label: "Wrong Answer",
          data: wrongAnswers,
          backgroundColor: "#FF3D00",
        }
      ]
    }
  }

  const getPieData = () => {
    let correctAnswers = 0;
    let wrongAnswers = 0;

    exam.result.forEach(element => {
      if (element.correct) {
        correctAnswers++;
      }else {
        wrongAnswers++;
      }
    });

    return {
      labels: ["Correct Answer", "Wrong Answer"],
      datasets: [
        {
          label: "Count",
          data: [correctAnswers, wrongAnswers],
          backgroundColor: ["#00E676", "#FF3D00"],
        },
      ]
    }
  }

  const calculatePoint = () => {
    let point = 0;

    exam.result.forEach(element => {
      if (element.correct) {
        point += 10;
      }
    });
    return point;
  }

  return (
    <>
      <NavbarComponent></NavbarComponent>
      <div className="exam-result-page">
        <div className="pt-3 pb-3 fs-2">Exam Result</div>
        <Row className="mx-0 pb-3">

          <Col lg={6} className="ps-4">
            <p className="fs-4">Total: {calculatePoint()} points</p>
            <p className="fs-5 pb-5">{calculatePoint() >= 70 ? "You can continue with next lesson" : "Review the lesson and try again"}</p>
            <Bar data={getBarData()} options={optionsBar}></Bar>
          </Col>

          <Col lg={6} className="pie-chart">
            <Pie data={getPieData()} options={optionsPie}></Pie>
          </Col>

        </Row>
      </div>
    </>
  )
}

export default ExamResultPage