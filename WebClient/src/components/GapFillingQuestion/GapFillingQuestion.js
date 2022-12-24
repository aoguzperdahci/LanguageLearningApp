import React, { useState } from 'react';
import { Button, Form, InputGroup } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import { saveAnswer } from '../../redux/ExamSlice';
import "./GapFillingQuestion.css";

const GapFillingQuestion = () => {

    const student = useSelector(state => state.user);
    const exam = useSelector(state => state.exam);
    const dispatch = useDispatch();
    const [answer, setAnswer] = useState("");

    const renderExamDifficulty = () => {
        let difficulty = <></>
        switch (exam.question.difficulty) {
            case 0:
                difficulty = <span className="text-success">Easy</span>
                break;
            case 1:
                difficulty = <span className="text-warning">Medium</span>
                break;
            case 2:
                difficulty = <span className="text-danger">Hard</span>
                break;
            default:
                break;
        }

        return difficulty;
    }

    const submitAnswer = () => {
        dispatch(saveAnswer({studentId: student.id, answer:answer}));
    }

    return (
        <div className="gap-filling-question">
            <div className="w-50 d-inline-block text-start fs-5">Question: {exam.questionNumber}/10</div>
            <div className="w-50 d-inline-block text-end fs-5">Difficulty: {renderExamDifficulty()}</div>
            <p className="fs-4 mt-4">Fill the blank by writing the answer for the question below.</p>
            <p className="fs-4 mt-2">{exam.question.questionText}</p>

            <InputGroup className="mb-4 mt-4">
                <InputGroup.Text className="bg-yellow">Answer:</InputGroup.Text>
                <Form.Control className="fs-5" placeholder="Write the answer" onChange={(e) => setAnswer(e.target.value)} />
            </InputGroup>

            <Button className="fs-5 py-2 px-3 question-submit-button" onClick={() => submitAnswer()} disabled={exam.status === "loading"}>{exam.questionNumber === 10 ? "Finish Exam" : "Next Question"}</Button>
        </div>
    )
}

export default GapFillingQuestion