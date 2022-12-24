import React, { useEffect } from 'react';
import { Button } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import GapFillingQuestion from '../../components/GapFillingQuestion/GapFillingQuestion';
import TestQuestion from '../../components/TestQuestion/TestQuestion';
import { createExam, getExamResult, getNextQuestion } from '../../redux/ExamSlice';
import "./ExamPage.css";

const ExamPage = () => {
    const student = useSelector(state => state.user);
    const exam = useSelector(state => state.exam);
    const dispatch = useDispatch();
    const navigate = useNavigate();

    useEffect(() => {
        console.log(exam)
        if (exam.status === "created") {
            dispatch(getNextQuestion(student.id));
        } else if (exam.status === "saved" && exam.questionNumber < 10) {
            dispatch(getNextQuestion(student.id));
        } else if (exam.status === "saved" && exam.questionNumber === 10) {
            dispatch(getExamResult(student.id));
            navigate("/exam-result");
        }
    }, [exam.status])

    const handleCreateExam = () => {
        dispatch(createExam(student.id));
    }

    const isTestQuestion = () => {
        if (exam.question.choiceA) {
            return true;
        } else {
            return false;
        }
    }

    return (
        <div className="exam-page d-flex justify-content-center" style={{ flexFlow: "wrap" }}>

            {exam.status === "empty" && <Button className="create-exam-button fs-4 px-5 py-2" onClick={() => handleCreateExam()} disabled={exam.status === "loading"}>Start Exam</Button>}

            {exam.status === "served" && (isTestQuestion() ? <TestQuestion></TestQuestion> : <GapFillingQuestion></GapFillingQuestion>)}

        </div>
    )
}

export default ExamPage